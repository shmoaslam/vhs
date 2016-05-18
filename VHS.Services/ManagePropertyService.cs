using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using VHS.Core;
using VHS.Interface;
using VHS.Repository;
using VHS.Services.Interface;
using VHS.Services.Models;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public class ManagePropertyService : IManageProperty
    {
        private readonly UnitOfWork _unitOfWork;
        private IProperty _property;
        private IManageRm _manageRm;
        public ManagePropertyService(IProperty property, IManageRm manageRm, UnitOfWork unitOfWork)
        {
            _property = property;
            _manageRm = manageRm;
            _unitOfWork = unitOfWork;
        }
        public PropertyRMViewModel GetAssignedProperty()
        {
            var manageProperty = new PropertyRMViewModel();
            var propertyList = _property.GetPropertyList().Where(m => m.IsAssigned == false).ToList();
            //var rmPropMapList = GetPropRmMap();
            //var result = (from prop in propertyList
            //              join rpm in rmPropMapList on prop.PropertyId equals rpm.ProprtyId into s
            //              from spm in s.DefaultIfEmpty()
            //              select new PropertyViewModel { PropertyId = prop.PropertyId, PropertyName = prop.PropertyName, ShortInfo = prop.ShortInfo, PropertImageList = prop.PropertImageList, RmId = spm == null ? 0 : spm.RMId }).ToList();
            manageProperty.proppertyVMList = propertyList.ToList();
            manageProperty.SelectedRm = RMList();
            return manageProperty;
        }
        private SelectList RMList()
        {
            List<ddlRM> listRm = new List<ddlRM>();
            var rmList = _manageRm.GetRmList();
            foreach (var item in rmList)
            {
                listRm.Add(new ddlRM { Value = item.RMId, Text = item.RMName });
            }
            SelectList selectedRm = new SelectList(listRm, "Value", "Text");
            return selectedRm;
        }
        public bool SetPropertyToRm(PropertyRMViewModel proprmView)
        {

            try
            {
                bool flag = false;
                var propertyCheck = _unitOfWork.PropertyRMMapRepository.Get(m => m.PropertyId == proprmView.hdnPropertyId);
                if (propertyCheck != null)
                {
                    propertyCheck.LoginId = proprmView.RmId;
                    _unitOfWork.PropertyRMMapRepository.Update(propertyCheck);
                    _unitOfWork.Save();
                    flag = true;
                }
                else
                {
                    var propRMMapCore = new PropertyRMMapping();
                    propRMMapCore.PropertyId = proprmView.hdnPropertyId;
                    propRMMapCore.LoginId = proprmView.RmId;
                    _unitOfWork.PropertyRMMapRepository.Insert(propRMMapCore);
                    _unitOfWork.Save();
                    flag = true;
                }
                if (flag)
                {
                    var property = _unitOfWork.PropertyRepository.GetByID(Convert.ToInt32(proprmView.hdnPropertyId));
                    if (property != null)
                    {
                        property.IsAssigned = true;
                        _unitOfWork.PropertyRepository.Update(property);
                        _unitOfWork.Save();

                    }
                }
                return flag;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public List<PropertyRMMap> GetPropRmMap()
        {
            var listPropRmMap = new List<PropertyRMMap>();
            var propertyCheck = _unitOfWork.PropertyRMMapRepository.GetAll();
            if (propertyCheck != null)
            {
                foreach (var item in propertyCheck)
                {
                    listPropRmMap.Add(new PropertyRMMap { PropRmMapId = item.id, ProprtyId = item.PropertyId, RMId = item.LoginId });
                }

            }
            return listPropRmMap;
        }


        //Getting Property Detail:-
        public PropertyEditViewModel GetPropertyDetail(int PropertyId)
        {
            var propertyEditViewModel = new PropertyEditViewModel();
            propertyEditViewModel.propertyGeneralInfo = GetPropertyGeneralInfo(PropertyId);
            propertyEditViewModel.propertyAdditionalInfo = GetPropertyAdditionalInfo(PropertyId);
            propertyEditViewModel.propertyAmenities = GetPropertyAmenities(PropertyId);
            //propertyEditViewModel.propertyFixPricing = GetPropertyFixedPricing(PropertyId);
            //propertyEditViewModel.propertVarablePricing = GetPropertyVarablePrice(PropertyId);
            propertyEditViewModel.propertyCoverPhoto = GetPropertyCoverPhoto(PropertyId);
            propertyEditViewModel.propertyGallaryPhoto = GetPropertyGallaryPhoto(PropertyId);
            propertyEditViewModel.propertyTravelAmbassdor = GetPropertyTravelAmbassReview(PropertyId);
            //propertyEditViewModel.propertyTransfer = GetPropertyTransferDetail(PropertyId);
            propertyEditViewModel.propertyDelete = GetPropertyDelete(PropertyId);
            propertyEditViewModel.propertyApproval = GetPropertyApproval(PropertyId);
            return propertyEditViewModel;
        }

        public PropertyGeneralInfo GetPropertyGeneralInfo(int PropertyId)
        {
            var propertyGeneralInfo = new PropertyGeneralInfo();
            var propGenralIngoobj = _unitOfWork.PropertyRepository.GetByID(PropertyId);
            if (propGenralIngoobj != null)
            {
                propertyGeneralInfo.PropertyId = propGenralIngoobj.Id;
                propertyGeneralInfo.Title = propGenralIngoobj.Title;
                propertyGeneralInfo.CategoryId = propGenralIngoobj.CategoryId;
                propertyGeneralInfo.Category = GetCategory();
                propertyGeneralInfo.ListById = propGenralIngoobj.ListedId;
                propertyGeneralInfo.ListBy = GetListBy();
                propertyGeneralInfo.NoOfGuests = propGenralIngoobj.NumberOfGuest;
                propertyGeneralInfo.NoOfRooms = propGenralIngoobj.NumberOfRooms;
                propertyGeneralInfo.NoOfBathrooms = propGenralIngoobj.NumberOfBathRoom;
                propertyGeneralInfo.Price = propGenralIngoobj.Price;
                propertyGeneralInfo.RegionId = propGenralIngoobj.RegionId;
                propertyGeneralInfo.Region = GetRegion();

                var propAddressobj = _unitOfWork.PropertyAddressRepository.GetFirst(m => m.PropertyId == PropertyId);
                if (propAddressobj != null)
                {
                    propertyGeneralInfo.Address = propAddressobj.Address;
                    propertyGeneralInfo.City = propAddressobj.City;
                    propertyGeneralInfo.Country = propAddressobj.Country;
                    propertyGeneralInfo.ZipCode = propAddressobj.ZipCode;
                    propertyGeneralInfo.ContactNo = propAddressobj.ContactNo;
                    propertyGeneralInfo.Email = propAddressobj.Email;
                }
            }
            else
            {
                propertyGeneralInfo.Category = GetCategory();
                propertyGeneralInfo.ListBy = GetListBy();
                propertyGeneralInfo.Region = GetRegion();
            }
            return propertyGeneralInfo;
        }
        public PropertyAdditionalInfoModel GetPropertyAdditionalInfo(int propertyId)
        {
            var propertyAdditionalInfo = new PropertyAdditionalInfoModel();
            var blakDay = new List<BlakOutDate>();
            propertyAdditionalInfo.PropertyId = propertyId;
            propertyAdditionalInfo.DrinkingAllowed = GetDrinkingAllowed();
            propertyAdditionalInfo.SmokeAllowed = GetSmokingAllowed();
            propertyAdditionalInfo.FamilyKidAllowed = GetFamilyAllowed();
            propertyAdditionalInfo.PetsAllowed = GetPetsAllowed();
            propertyAdditionalInfo.WheelChairAllowed = GetWheelChairAllowed();
            propertyAdditionalInfo.ProperyRating = GetPropertyRatingList();

            var propAdditional = _unitOfWork.PropertyAdditionalRepository.Get(m => m.PropertyId == propertyId);
            if (propAdditional != null)
            {

                propertyAdditionalInfo.PropAdditionalId = propAdditional.id;
                propertyAdditionalInfo.PropertyDescription = propAdditional.PropDescription;
                propertyAdditionalInfo.CheckIn = propAdditional.CheckInTime;
                propertyAdditionalInfo.CheckOut = propAdditional.CheckOutTime;
                propertyAdditionalInfo.DrinkAllowedId = Convert.ToInt32(propAdditional.IsDrinikingAllowed);
                propertyAdditionalInfo.SmokeAllowedId = Convert.ToInt32(propAdditional.IsSmokingAllowed);
                propertyAdditionalInfo.FamilyKidAllowedId = Convert.ToInt32(propAdditional.IsFamKidFriendAllowed);
                propertyAdditionalInfo.PetsAllowedId = Convert.ToInt32(propAdditional.IsPetsAllowed);
                propertyAdditionalInfo.WheelChairId = Convert.ToInt32(propAdditional.IsWheelChairAccess);
                propertyAdditionalInfo.PropertySize = Convert.ToInt32(propAdditional.PropertySize);
                propertyAdditionalInfo.PropRatingId = Convert.ToInt32(propAdditional.PropertyRating);
                propertyAdditionalInfo.MaxGuest = Convert.ToInt32(propAdditional.MaxGuest);
                propertyAdditionalInfo.Logitude = propAdditional.MapLongitude;
                propertyAdditionalInfo.Latitude = propAdditional.MapLatitude;
                propertyAdditionalInfo.PersonPerRoom = propAdditional.PersonPerRoom;

            }



            blakDay.Add(new BlakOutDate { StartDate = DateTime.Now.ToString(), EndDate = DateTime.Now.AddDays(5).ToString() });
            propertyAdditionalInfo.BlackOutDatsList = blakDay;

            return propertyAdditionalInfo;
        }
        public PropertyAmenities GetPropertyAmenities(int propertyId)
        {
            var propertyAmenities = new PropertyAmenities();
            propertyAmenities.PropertyId = propertyId;
            propertyAmenities.BathRoomsList = GetAllBathRooms(propertyId);
            propertyAmenities.ParkingList = GetAllParking(propertyId);
            propertyAmenities.SleepingArrangmentList = GetAllSleepingArrangment(propertyId);
            propertyAmenities.KitchenList = GetAllKitchen(propertyId);
            propertyAmenities.GeneralList = GetAllGeneral(propertyId);
            propertyAmenities.EnterTaimentElecList = GetAllEnterTaimentElec(propertyId);
            propertyAmenities.OutdoorFacilitiesList = GetAllOutdoorFacilities(propertyId);
            return propertyAmenities;
        }
        public PropertyFixedPricing GetPropertyFixedPrice(int propertyId)
        {
            var propertyFixedPrice = new PropertyFixedPricing();
            propertyFixedPrice.PropertyId = propertyId;
            propertyFixedPrice.PriceCurrency = GetCurrencyList();

            var propfixedPrice = _unitOfWork.PropFixedPriceRepository.Get(m => m.PropertyId == propertyId);
            if (propfixedPrice != null)
            {
                propertyFixedPrice.PricePerNight = Convert.ToDouble(propfixedPrice.PricePerNight);
                propertyFixedPrice.PricePerWeek = Convert.ToDouble(propfixedPrice.PricePerWeek);
                propertyFixedPrice.PricePerMonth = Convert.ToDouble(propfixedPrice.PricePerMonth);
                propertyFixedPrice.PriceOneTime = Convert.ToDouble(propfixedPrice.OneTimeFee);
                propertyFixedPrice.OtherPrice = propfixedPrice.OtherFee;
                propertyFixedPrice.CleaningFeeWeekly = Convert.ToDouble(propfixedPrice.CleaningFeeWeek);
                propertyFixedPrice.CleaningFeeDaily = Convert.ToDouble(propfixedPrice.CleaningFeeDaily);
                propertyFixedPrice.CleaningFeeMonthly = Convert.ToDouble(propfixedPrice.CleaningFeeMonth);
                propertyFixedPrice.PropFixedPriceId = propfixedPrice.id;
                propertyFixedPrice.Comision = propfixedPrice.Comision;
                propertyFixedPrice.CurrencyId = Convert.ToInt32(propfixedPrice.Currency);
            }

            return propertyFixedPrice;
        }
        public PropertyVarablePricing GetPropertyVaraiablePrice(int propertyId)
        {
            var propertyPricevarable = new PropertyVarablePricing();
            propertyPricevarable.PropertyId = propertyId;

            var propVariablePrice = _unitOfWork.PropVariablePriceRepository.Get(m => m.PropertyId == propertyId);
            if (propVariablePrice != null)
            {
                propertyPricevarable.StartDate = new DateTime(propVariablePrice.StartDate.Year, propVariablePrice.StartDate.Month, propVariablePrice.StartDate.Day);
                propertyPricevarable.StopDate = new DateTime(propVariablePrice.EndDate.Year, propVariablePrice.EndDate.Month, propVariablePrice.EndDate.Day);
                propertyPricevarable.Description = propVariablePrice.Description;
                propertyPricevarable.Price = Convert.ToDouble(propVariablePrice.Price);
                propertyPricevarable.PropVarPriceId = propVariablePrice.id;
            }
            return propertyPricevarable;
        }

        public PropertyWeekendPricing GetPropertyWeekendPrice(int propertyId)
        {
            var propertyPriceWeekend = new PropertyWeekendPricing();
            propertyPriceWeekend.PropertyId = propertyId;

            var propWePrice = _unitOfWork.PropertyWeekendPriceRepository.Get(m => m.PropertyId == propertyId);
            if (propWePrice != null)
            {
                propertyPriceWeekend.Price = propWePrice.Price;
                propertyPriceWeekend.From = propWePrice.From;
                propertyPriceWeekend.To = propWePrice.To;
                propertyPriceWeekend.PropertyId = propWePrice.PropertyId;
                propertyPriceWeekend.PropWEPriceId = propWePrice.Id;
            }
            return propertyPriceWeekend;
        }
        public PropertyCoverPhoto GetPropertyCoverPhoto(int propertyId)
        {
            var propertyPhoto = new PropertyCoverPhoto();
            var photo = new List<ImagePhoto>();
            var propCoverPhoto = _unitOfWork.PropCoverPhotoRepository.GetMany(m => m.PropertyId == propertyId).ToList();
            var imagePhoto = _unitOfWork.ImageRepository.Get();
            //var reult=from propcover in propCoverPhoto 
            //          join imagePhoto in
            if (propCoverPhoto != null)
            {
                foreach (var item in propCoverPhoto)
                {
                    photo.Add(new ImagePhoto { ImageId = item.ImageId, ImageName = imagePhoto.Single(m => m.ImageId == item.ImageId).Name });
                }
            }

            propertyPhoto.PropertyId = propertyId;
            propertyPhoto.imageCoverPhoto = photo;
            return propertyPhoto;
        }
        public PropertyGallaryPhoto GetPropertyGallaryPhoto(int propertyId)
        {
            var propertyPhoto = new PropertyGallaryPhoto();
            var photo = new List<ImagePhoto>();
            var propCoverPhoto = _unitOfWork.PropertyGallaryRepository.GetMany(m => m.PropertyId == propertyId).ToList();
            var imagePhoto = _unitOfWork.ImageRepository.Get();
            //var reult=from propcover in propCoverPhoto 
            //          join imagePhoto in
            if (propCoverPhoto != null)
            {
                foreach (var item in propCoverPhoto)
                {
                    photo.Add(new ImagePhoto { ImageId = item.ImageId, ImageName = imagePhoto.Single(m => m.ImageId == item.ImageId).Name });
                }
            }
            propertyPhoto.PropertyId = propertyId;
            propertyPhoto.imageGalaryPhoto = photo;
            return propertyPhoto;
        }
        public PropertyTravelAmbassador GetPropertyTravelAmbassReview(int PropertyId)
        {
            var propertyTravleAmbassReview = new PropertyTravelAmbassador();
            return propertyTravleAmbassReview;
        }
        public PropertyTransfer GetPropertyTransfer(int PropertyId)
        {
            var propertyTransfer = new PropertyTransfer();
            var propRm = _unitOfWork.PropertyRMMapRepository.Get(m => m.PropertyId == PropertyId);
            if (propRm != null)
            {
                propertyTransfer.RmId = propRm.LoginId;

            }
            propertyTransfer.SelectedRm = RMList();
            propertyTransfer.PropertyId = PropertyId;
            return propertyTransfer;
        }
        public PropertyNotification GetPropertyDelete(int PropertyId)
        {
            var propertyDelete = new PropertyNotification();
            propertyDelete.PropertyId = PropertyId;
            return propertyDelete;
        }
        public PropertyNotification GetPropertyApproval(int PropertyId)
        {
            var propertyDelete = new PropertyNotification();
            propertyDelete.PropertyId = PropertyId;
            return propertyDelete;
        }
        //Update Property Detail:-
        public bool UpdateGeneralInfo(PropertyGeneralInfo propGeneralInfo, List<HttpPostedFileBase> file)
        {
            var result = false;
            if (propGeneralInfo.PropertyId != 0)
            {
                var propertObj = _unitOfWork.PropertyRepository.GetByID(propGeneralInfo.PropertyId);
                propertObj.Title = propGeneralInfo.Title;
                propertObj.NumberOfBathRoom = propGeneralInfo.NoOfBathrooms;
                propertObj.NumberOfGuest = propGeneralInfo.NoOfGuests;
                propertObj.NumberOfRooms = propGeneralInfo.NoOfRooms;
                propertObj.Price = propGeneralInfo.Price;
                propertObj.ListedId = propGeneralInfo.ListById;
                propertObj.CategoryId = propGeneralInfo.CategoryId;
                propertObj.IsApproved = false;
                propertObj.RegionId = propGeneralInfo.RegionId;
                _unitOfWork.PropertyRepository.Update(propertObj);
                _unitOfWork.Save();
                //Create Property Address:-
                var propAddressObj = _unitOfWork.PropertyAddressRepository.GetSingle(m => m.PropertyId == propGeneralInfo.PropertyId);
                propAddressObj.PropertyId = propertObj.Id;
                propAddressObj.Address = propGeneralInfo.Address;
                propAddressObj.City = propGeneralInfo.City;
                propAddressObj.Country = propGeneralInfo.Country;
                propAddressObj.ZipCode = propGeneralInfo.ZipCode;
                propAddressObj.Email = propGeneralInfo.Email;
                propAddressObj.ContactNo = propGeneralInfo.ContactNo;
                _unitOfWork.PropertyAddressRepository.Update(propAddressObj);
                _unitOfWork.Save();
                //Create Property Image:-
                if (file.Count > 0)
                {
                    _unitOfWork.PropertyImageMapRepository.Delete(m => m.PropertyId == propGeneralInfo.PropertyId);
                    foreach (var item in file)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.FileName))
                        {
                            var imageObj = new Core.Image();
                            string extension = Path.GetExtension(item.FileName).ToString();
                            string filename = Path.GetFileNameWithoutExtension(item.FileName) + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadFile/PropertyImage/"), filename);
                            item.SaveAs(path);
                            imageObj.Name = filename;
                            _unitOfWork.ImageRepository.Insert(imageObj);
                            _unitOfWork.Save();

                            _unitOfWork.PropertyImageMapRepository.Insert(new PropertyImageMapping { ImageId = imageObj.ImageId, PropertyId = propGeneralInfo.PropertyId });
                            _unitOfWork.Save();
                        }
                    }
                    result = true;
                }
            }
            else
            {
                var propertObj = new Core.Property();
                propertObj.Title = propGeneralInfo.Title;

                propertObj.NumberOfBathRoom = propGeneralInfo.NoOfBathrooms;
                propertObj.NumberOfGuest = propGeneralInfo.NoOfGuests;
                propertObj.NumberOfRooms = propGeneralInfo.NoOfRooms;
                propertObj.Price = propGeneralInfo.Price;
                propertObj.ListedId = propGeneralInfo.ListById;
                propertObj.CategoryId = propGeneralInfo.CategoryId;
                propertObj.IsApproved = false;
                propertObj.LoginId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                _unitOfWork.PropertyRepository.Insert(propertObj);
                _unitOfWork.Save();
                //Create Property Address:-
                var propAddressObj = new Core.PropertyAddress();
                propAddressObj.PropertyId = propertObj.Id;
                propAddressObj.Address = propGeneralInfo.Address;
                propAddressObj.City = propGeneralInfo.City;
                propAddressObj.Country = propGeneralInfo.Country;
                propAddressObj.ZipCode = propGeneralInfo.ZipCode;
                propAddressObj.Email = propGeneralInfo.Email;
                propAddressObj.ContactNo = propGeneralInfo.ContactNo;
                _unitOfWork.PropertyAddressRepository.Insert(propAddressObj);
                _unitOfWork.Save();
                //Create Property Image:-
                if (file.Count > 0)
                {
                    foreach (var item in file)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.FileName))
                        {
                            var imageObj = new Core.Image();
                            string extension = Path.GetExtension(item.FileName).ToString();
                            string filename = Path.GetFileNameWithoutExtension(item.FileName) + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadFile/PropertyImage/"), filename);
                            item.SaveAs(path);
                            imageObj.Name = filename;
                            _unitOfWork.ImageRepository.Insert(imageObj);
                            _unitOfWork.Save();

                            var imgPropMap = new Core.PropertyImageMapping();
                            imgPropMap.ImageId = imageObj.ImageId;
                            imgPropMap.PropertyId = propertObj.Id;
                            _unitOfWork.PropertyImageMapRepository.Insert(imgPropMap);
                            _unitOfWork.Save();
                        }
                    }
                    result = true;
                }
            }




            return result;
        }

        //public bool UpdateAppearanceSetting(PropertyApperance propPhoto, List<HttpPostedFileBase> ImageCoverPhoto, List<HttpPostedFileBase> ImageGallaryPhoto)
        //{
        //    var result = false;
        //    return result;
        //}
        public bool UpdateTravelAmbassador(PropertyTravelAmbassador propTravelAmbass)
        {
            var result = false;
            return result;
        }

        public List<PropertyViewModel> GetPropertyForManage(int rmID)
        {
            var rmHomeVm = new List<PropertyViewModel>();

            var propList = _unitOfWork.GetPropertyListForAdmin(rmID);

            if (propList != null)
                foreach (var prop in propList)
                    rmHomeVm.Add(new PropertyViewModel { PropertyId = prop.Id, PropertyName = prop.Name });
            return rmHomeVm;
        }
        public SelectList GetCategory()
        {
            var lstCategory = new List<ddlCategory>();
            lstCategory.Add(new ddlCategory { Value = 1, Text = "Apartment" });
            lstCategory.Add(new ddlCategory { Value = 2, Text = "Beach House" });
            lstCategory.Add(new ddlCategory { Value = 3, Text = "Boat House" });
            lstCategory.Add(new ddlCategory { Value = 4, Text = "Farmhouse" });
            lstCategory.Add(new ddlCategory { Value = 5, Text = "Private Room" });
            lstCategory.Add(new ddlCategory { Value = 6, Text = "Villa" });
            lstCategory.Add(new ddlCategory { Value = 7, Text = "Other" });
            SelectList selesctedCategory = new SelectList(lstCategory, "Value", "Text");
            return selesctedCategory;
        }
        public SelectList GetListBy()
        {
            var lstListBy = new List<ddlListedBy>();
            lstListBy.Add(new ddlListedBy { Value = 1, Text = "Owner" });
            lstListBy.Add(new ddlListedBy { Value = 1, Text = "Representative" });
            SelectList selesctedListBy = new SelectList(lstListBy, "Value", "Text");
            return selesctedListBy;
        }
        public SelectList GetRegion()
        {
            var lstRegion = new List<ddlRegion>();
            lstRegion.Add(new ddlRegion { Value = 1, Text = "Konkan" });
            lstRegion.Add(new ddlRegion { Value = 2, Text = "Spain" });
            SelectList selesctedRegion = new SelectList(lstRegion, "Value", "Text");
            return selesctedRegion;
        }

        public SelectList GetPetsAllowed()
        {
            var lstpets = new List<ddlPetsAllowed>();
            lstpets.Add(new ddlPetsAllowed { Value = 1, Text = "Yes" });
            lstpets.Add(new ddlPetsAllowed { Value = 2, Text = "No" });
            SelectList selesctedCategory = new SelectList(lstpets, "Value", "Text");
            return selesctedCategory;
        }
        public SelectList GetDrinkingAllowed()
        {
            var lstListBy = new List<ddlDrinkingAllowed>();
            lstListBy.Add(new ddlDrinkingAllowed { Value = 1, Text = "Yes" });
            lstListBy.Add(new ddlDrinkingAllowed { Value = 2, Text = "No" });
            SelectList selesctedListBy = new SelectList(lstListBy, "Value", "Text");
            return selesctedListBy;
        }
        public SelectList GetSmokingAllowed()
        {
            var lstListBy = new List<ddlSmokingAllowed>();
            lstListBy.Add(new ddlSmokingAllowed { Value = 1, Text = "Yes" });
            lstListBy.Add(new ddlSmokingAllowed { Value = 2, Text = "No" });
            SelectList selesctedListBy = new SelectList(lstListBy, "Value", "Text");
            return selesctedListBy;
        }
        public SelectList GetFamilyAllowed()
        {
            var lstListBy = new List<ddlFamilyKidAllowed>();
            lstListBy.Add(new ddlFamilyKidAllowed { Value = 1, Text = "Yes" });
            lstListBy.Add(new ddlFamilyKidAllowed { Value = 2, Text = "No" });
            SelectList selesctedListBy = new SelectList(lstListBy, "Value", "Text");
            return selesctedListBy;
        }
        public SelectList GetWheelChairAllowed()
        {
            var lstListBy = new List<ddlWheelChailAccessible>();
            lstListBy.Add(new ddlWheelChailAccessible { Value = 1, Text = "Yes" });
            lstListBy.Add(new ddlWheelChailAccessible { Value = 2, Text = "No" });
            SelectList selesctedListBy = new SelectList(lstListBy, "Value", "Text");
            return selesctedListBy;
        }
        public SelectList GetCurrencyList()
        {
            var lstPriceCurrency = new List<ddlPriceCurrency>();
            lstPriceCurrency.Add(new ddlPriceCurrency { Value = 1, Text = "Indian Rupees" });
            lstPriceCurrency.Add(new ddlPriceCurrency { Value = 2, Text = "Euro" });
            lstPriceCurrency.Add(new ddlPriceCurrency { Value = 3, Text = "Doller" });
            lstPriceCurrency.Add(new ddlPriceCurrency { Value = 4, Text = "Sterling Pound" });
            SelectList selesctedListBy = new SelectList(lstPriceCurrency, "Value", "Text");
            return selesctedListBy;
        }
        public SelectList GetPropertyRatingList()
        {
            var lstPropRating = new List<ddlPropertyRating>();
            lstPropRating.Add(new ddlPropertyRating { Value = 1, Text = "3" });
            lstPropRating.Add(new ddlPropertyRating { Value = 2, Text = "3.5" });
            lstPropRating.Add(new ddlPropertyRating { Value = 3, Text = "4" });
            lstPropRating.Add(new ddlPropertyRating { Value = 4, Text = "4.5" });
            lstPropRating.Add(new ddlPropertyRating { Value = 4, Text = "5" });

            SelectList selesctedListBy = new SelectList(lstPropRating, "Value", "Text");
            return selesctedListBy;
        }

        //Master Aminities List:-
        public IEnumerable<ViewModel.BathRommsModel> GetAllBathRooms(int propertyId)
        {
            var bathRooms = _unitOfWork.BathRoomsRepository.GetAll();
            var propBathRoomMap = _unitOfWork.PropBathRoomRepository.GetMany(x => x.PropertyId == propertyId);

            var bathRoom = new List<ViewModel.BathRommsModel>();

            foreach (var item in bathRooms)
            {
                bathRoom.Add(new ViewModel.BathRommsModel { id = item.id, Name = item.Name, IsChecked = propBathRoomMap.Any(x => x.BathRoomId == item.id) });
            }
            return bathRoom;
        }
        public IEnumerable<ViewModel.ParkingModel> GetAllParking(int propertyId)
        {
            var parking = _unitOfWork.ParkingRepository.GetAll();
            var propParkingMap = _unitOfWork.PropParkingRepository.GetMany(x => x.PropertyId == propertyId);

            var parkingList = new List<ViewModel.ParkingModel>();

            foreach (var item in parking)
            {
                parkingList.Add(new ViewModel.ParkingModel { id = item.id, Name = item.Name, IsChecked = propParkingMap.Any(x => x.ParkingId == item.id) });
            }
            return parkingList;
        }
        public IEnumerable<ViewModel.SleepingArrangmentModel> GetAllSleepingArrangment(int propertyId)
        {
            var sleepingArrengment = _unitOfWork.SleepingArrangementRepository.GetAll();
            var propSleepMap = _unitOfWork.PropSleepingRepository.GetMany(x => x.PropertyId == propertyId);

            var sleepingList = new List<ViewModel.SleepingArrangmentModel>();

            foreach (var item in sleepingArrengment)
            {
                sleepingList.Add(new ViewModel.SleepingArrangmentModel { id = item.id, Name = item.Name, IsChecked = propSleepMap.Any(x => x.SleepArrengId == item.id) });
            }
            return sleepingList;
        }
        public IEnumerable<ViewModel.KitchenModel> GetAllKitchen(int propertyId)
        {
            var kitchen = _unitOfWork.KitchenRepository.GetAll();
            var propKitchenMap = _unitOfWork.PropKitchenRepository.GetMany(x => x.PropertyId == propertyId);

            var litchenList = new List<ViewModel.KitchenModel>();

            foreach (var item in kitchen)
            {
                litchenList.Add(new ViewModel.KitchenModel { id = item.id, Name = item.Name, IsChecked = propKitchenMap.Any(x => x.KitchenId == item.id) });
            }
            return litchenList;
        }
        public IEnumerable<ViewModel.GeneralModel> GetAllGeneral(int propertyId)
        {
            var general = _unitOfWork.GeneralRepository.GetAll();
            var propGeberalMap = _unitOfWork.PropGeneralRepository.GetMany(x => x.PropertyId == propertyId);

            var generalList = new List<ViewModel.GeneralModel>();

            foreach (var item in general)
            {
                generalList.Add(new ViewModel.GeneralModel { id = item.id, Name = item.Name, IsChecked = propGeberalMap.Any(x => x.GeneralId == item.id) });
            }
            return generalList;
        }
        public IEnumerable<ViewModel.EnterTaimentElecModel> GetAllEnterTaimentElec(int propertyId)
        {
            var enterElec = _unitOfWork.EntertinmentElecRepository.GetAll();
            var propEnterElecMap = _unitOfWork.PropEnterERepository.GetMany(x => x.PropertyId == propertyId);

            var enterElecList = new List<ViewModel.EnterTaimentElecModel>();

            foreach (var item in enterElec)
            {
                enterElecList.Add(new ViewModel.EnterTaimentElecModel { id = item.id, Name = item.Name, IsChecked = propEnterElecMap.Any(x => x.EnterElecId == item.id) });
            }
            return enterElecList;
        }
        public IEnumerable<ViewModel.OutdoorFacilitiesModel> GetAllOutdoorFacilities(int propertyId)
        {
            var outDoorobj = _unitOfWork.OutdoorFaciRepository.GetAll();
            var propOutDoorMap = _unitOfWork.PropOutdoorRepository.GetMany(x => x.PropertyId == propertyId);

            var outDoor = new List<ViewModel.OutdoorFacilitiesModel>();

            foreach (var item in outDoorobj)
            {
                outDoor.Add(new ViewModel.OutdoorFacilitiesModel { id = item.id, Name = item.Name, IsChecked = propOutDoorMap.Any(x => x.OutFaciId == item.id) });
            }
            return outDoor;
        }


        public bool UpdateAdditionalInfo(PropertyAdditionalInfoModel propAdditionalInfoInfo)
        {
            var result = false;
            if (propAdditionalInfoInfo.PropAdditionalId == 0)
            {
                _unitOfWork.PropertyAdditionalRepository.Insert(new PropertyAdditionalInfo
                {
                    CheckInTime = propAdditionalInfoInfo.CheckIn,
                    CheckOutTime = propAdditionalInfoInfo.CheckOut,
                    IsDrinikingAllowed = propAdditionalInfoInfo.DrinkAllowedId.ToString(),
                    IsFamKidFriendAllowed = propAdditionalInfoInfo.FamilyKidAllowedId.ToString(),
                    IsSmokingAllowed = propAdditionalInfoInfo.FamilyKidAllowedId.ToString(),
                    IsWheelChairAccess = propAdditionalInfoInfo.WheelChairId.ToString(),
                    IsPetsAllowed = propAdditionalInfoInfo.PetsAllowedId.ToString(),
                    PropertySize = propAdditionalInfoInfo.PropertySize.ToString(),
                    PropertyId = propAdditionalInfoInfo.PropertyId,
                    MapLatitude = propAdditionalInfoInfo.Latitude,
                    MapLongitude = propAdditionalInfoInfo.Logitude,
                    PersonPerRoom = propAdditionalInfoInfo.PersonPerRoom,

                    PropertyRating = propAdditionalInfoInfo.PropRatingId.ToString(),
                    MaxGuest = propAdditionalInfoInfo.MaxGuest,

                    PropDescription = propAdditionalInfoInfo.PropertyDescription

                });
            }
            else
            {
                var propfixedobj = _unitOfWork.PropertyAdditionalRepository.GetFirst(m => m.PropertyId == propAdditionalInfoInfo.PropertyId);
                if (propfixedobj != null)
                {

                    propfixedobj.CheckInTime = propAdditionalInfoInfo.CheckIn;
                    propfixedobj.CheckOutTime = propAdditionalInfoInfo.CheckOut;
                    propfixedobj.IsDrinikingAllowed = propAdditionalInfoInfo.DrinkAllowedId.ToString();
                    propfixedobj.IsFamKidFriendAllowed = propAdditionalInfoInfo.FamilyKidAllowedId.ToString();
                    propfixedobj.IsSmokingAllowed = propAdditionalInfoInfo.FamilyKidAllowedId.ToString();
                    propfixedobj.IsWheelChairAccess = propAdditionalInfoInfo.WheelChairId.ToString();
                    propfixedobj.IsPetsAllowed = propAdditionalInfoInfo.PetsAllowedId.ToString();
                    propfixedobj.PropertySize = propAdditionalInfoInfo.PropertySize.ToString();
                    propfixedobj.MapLatitude = propAdditionalInfoInfo.Latitude;
                    propfixedobj.MapLongitude = propAdditionalInfoInfo.Logitude;
                    propfixedobj.PropDescription = propAdditionalInfoInfo.PropertyDescription;
                    propfixedobj.PersonPerRoom = propAdditionalInfoInfo.PersonPerRoom;
                    propfixedobj.MaxGuest = propAdditionalInfoInfo.MaxGuest;
                    propfixedobj.PropertyRating = propAdditionalInfoInfo.PropRatingId.ToString();
                    _unitOfWork.PropertyAdditionalRepository.Update(propfixedobj);
                }
            }
            //Saving and Updating BlackOut date:-
            if (propAdditionalInfoInfo.BlackOutDatsList != null && propAdditionalInfoInfo.BlackOutDatsList.Count > 0)
            {
                foreach (var item in propAdditionalInfoInfo.BlackOutDatsList)
                {
                    if (item.BlackOutDateId == 0)
                    {
                        _unitOfWork.PropertyBlackOutDateRepository.Insert(new PropertyBlackOutDay { PropertyId = propAdditionalInfoInfo.PropertyId, StartDate = Convert.ToDateTime(item.StartDate), EndDate = Convert.ToDateTime(item.EndDate) });
                    }
                    else
                    {
                        var propBlackOut = _unitOfWork.PropertyBlackOutDateRepository.GetByID(item.BlackOutDateId);
                        if (propBlackOut != null)
                        {
                            propBlackOut.StartDate = Convert.ToDateTime(item.StartDate);
                            propBlackOut.EndDate = Convert.ToDateTime(item.EndDate);
                            _unitOfWork.PropertyBlackOutDateRepository.Update(propBlackOut);
                        }
                    }
                }
            }
            _unitOfWork.Save();
            result = true;
            return result;
        }
        public bool UpdateAmenities(PropertyAmenities propAmenities)
        {
            bool result = false;

            if (propAmenities.ParkingId != null && propAmenities.ParkingId.Count() > 0)
            {
                _unitOfWork.PropParkingRepository.Delete(m => m.PropertyId == propAmenities.PropertyId);
                foreach (var parking in propAmenities.ParkingId)
                {
                    _unitOfWork.PropParkingRepository.Insert(new PropertyParkingMap { ParkingId = parking, PropertyId = propAmenities.PropertyId });
                }
                _unitOfWork.Save();
                result = true;
            }
            if (propAmenities.SleepingArrangmentId != null && propAmenities.SleepingArrangmentId.Count() > 0)
            {
                _unitOfWork.PropSleepingRepository.Delete(m => m.PropertyId == propAmenities.PropertyId);
                foreach (var sleeping in propAmenities.SleepingArrangmentId)
                {
                    _unitOfWork.PropSleepingRepository.Insert(new PropertySleepingMap { SleepArrengId = sleeping, PropertyId = propAmenities.PropertyId });
                }
                _unitOfWork.Save();
                result = true;
            }
            if (propAmenities.BathRoomsId != null && propAmenities.BathRoomsId.Count() > 0)
            {
                _unitOfWork.PropBathRoomRepository.Delete(m => m.PropertyId == propAmenities.PropertyId);
                foreach (var bathRoom in propAmenities.BathRoomsId)
                {
                    _unitOfWork.PropBathRoomRepository.Insert(new PropertyBathRoomsMap { BathRoomId = bathRoom, PropertyId = propAmenities.PropertyId });
                }
                _unitOfWork.Save();
                result = true;
            }
            if (propAmenities.KitchenId != null && propAmenities.KitchenId.Count() > 0)
            {
                _unitOfWork.PropKitchenRepository.Delete(m => m.PropertyId == propAmenities.PropertyId);
                foreach (var kitchen in propAmenities.KitchenId)
                {
                    _unitOfWork.PropKitchenRepository.Insert(new PropertyKitchenMap { KitchenId = kitchen, PropertyId = propAmenities.PropertyId });
                }
                _unitOfWork.Save();
                result = true;
            }
            if (propAmenities.GeneralId != null && propAmenities.GeneralId.Count() > 0)
            {
                _unitOfWork.PropGeneralRepository.Delete(m => m.PropertyId == propAmenities.PropertyId);
                foreach (var general in propAmenities.GeneralId)
                {
                    _unitOfWork.PropGeneralRepository.Insert(new PropertyGeneralMap { GeneralId = general, PropertyId = propAmenities.PropertyId });
                }
                _unitOfWork.Save();
                result = true;
            }
            if (propAmenities.EnterTaimentId != null && propAmenities.EnterTaimentId.Count() > 0)
            {
                _unitOfWork.PropEnterERepository.Delete(m => m.PropertyId == propAmenities.PropertyId);
                foreach (var enter in propAmenities.EnterTaimentId)
                {
                    _unitOfWork.PropEnterERepository.Insert(new PropertyEnterElecMap { EnterElecId = enter, PropertyId = propAmenities.PropertyId });
                }
                _unitOfWork.Save();
                result = true;
            }
            if (propAmenities.OutdoorId != null && propAmenities.OutdoorId.Count() > 0)
            {
                _unitOfWork.PropOutdoorRepository.Delete(m => m.PropertyId == propAmenities.PropertyId);
                foreach (var outdoor in propAmenities.OutdoorId)
                {
                    _unitOfWork.PropOutdoorRepository.Insert(new PropertyOutdoorMap { OutFaciId = outdoor, PropertyId = propAmenities.PropertyId });
                }
                _unitOfWork.Save();
                result = true;
            }
            return result;
        }

        public bool DeleteProperty(PropertyNotification propertyDelete)
        {
            var result = false;
            var propDelete = _unitOfWork.PropertyRepository.Get(m => m.Id == propertyDelete.PropertyId);
            if (propDelete != null)
            {
                propDelete.IsActive = false;
                _unitOfWork.PropertyRepository.Update(propDelete);
                _unitOfWork.Save();
                return true;
            }
            return result;
        }

        public bool UpdatePropGallaryPhoto(PropertyGallaryPhoto propertyGallaryPhoto, List<HttpPostedFileBase> GallaryPhoto)
        {
            bool result = false;
            if (GallaryPhoto.Count > 0)
            {
                _unitOfWork.PropertyGallaryRepository.Delete(m => m.PropertyId == propertyGallaryPhoto.PropertyId);
                foreach (var item in GallaryPhoto)
                {
                    var imageObj = new Core.Image();
                    string extension = Path.GetExtension(item.FileName).ToString();
                    string filename = Path.GetFileNameWithoutExtension(item.FileName) + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadFile/PropertyGallary/"), filename);
                    item.SaveAs(path);
                    imageObj.Name = filename;
                    _unitOfWork.ImageRepository.Insert(imageObj);
                    _unitOfWork.Save();
                    _unitOfWork.PropertyGallaryRepository.Insert(new PropertyGallaryMap { ImageId = imageObj.ImageId, PropertyId = propertyGallaryPhoto.PropertyId });
                    _unitOfWork.Save();

                }
                result = true;
            }
            return result;
        }

        public bool UpdatePropCoverPhoto(PropertyCoverPhoto propertyCoverPhoto, List<HttpPostedFileBase> CoverPhoto)
        {
            bool result = false;
            if (CoverPhoto.Count > 0)
            {
                _unitOfWork.PropCoverPhotoRepository.Delete(m => m.PropertyId == propertyCoverPhoto.PropertyId);
                foreach (var item in CoverPhoto)
                {
                    var imageObj = new Core.Image();
                    string extension = Path.GetExtension(item.FileName).ToString();
                    string filename = Path.GetFileNameWithoutExtension(item.FileName) + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadFile/PropertyCoverPhoto/"), filename);
                    item.SaveAs(path);
                    imageObj.Name = filename;
                    _unitOfWork.ImageRepository.Insert(imageObj);
                    _unitOfWork.Save();
                    _unitOfWork.PropCoverPhotoRepository.Insert(new PropertyCoverPhotoMap { ImageId = imageObj.ImageId, PropertyId = propertyCoverPhoto.PropertyId });
                    _unitOfWork.Save();

                }
                result = true;
            }
            return result;
        }

        public bool UpdatePropVariablePrice(PropertyVarablePricing propVarablePrice)
        {
            var result = false;
            if (propVarablePrice.PropVarPriceId == 0)
            {
                _unitOfWork.PropVariablePriceRepository.Insert(new PropertyVraiblePrice { Price = Convert.ToDecimal(propVarablePrice.Price), StartDate = propVarablePrice.StartDate, EndDate = propVarablePrice.StopDate, Description = propVarablePrice.Description, PropertyId = propVarablePrice.PropertyId });
            }
            else
            {
                var propvariaobj = _unitOfWork.PropVariablePriceRepository.GetByID(propVarablePrice.PropVarPriceId);
                if (propvariaobj != null)
                {
                    propvariaobj.Price = Convert.ToDecimal(propVarablePrice.Price);
                    propvariaobj.StartDate = propVarablePrice.StartDate;
                    propvariaobj.EndDate = propVarablePrice.StopDate;
                    propvariaobj.Description = propVarablePrice.Description;
                    _unitOfWork.PropVariablePriceRepository.Update(propvariaobj);
                }
            }
            _unitOfWork.Save();
            result = true;
            return result;
        }


        public bool UpdatePropWeekEndPrice(PropertyWeekendPricing propWePrice)
        {
            var result = false;
            if (propWePrice.PropWEPriceId == 0)
            {
                _unitOfWork.PropertyWeekendPriceRepository.Insert(new PropertyWeekendPrice { Price = Convert.ToDecimal(propWePrice.Price), From = propWePrice.From, To = propWePrice.To, PropertyId = propWePrice.PropertyId });
            }
            else
            {
                var propWEobj = _unitOfWork.PropertyWeekendPriceRepository.GetByID(propWePrice.PropWEPriceId);
                if (propWEobj != null)
                {
                    propWEobj.Price = Convert.ToDecimal(propWePrice.Price);
                    propWEobj.From = propWePrice.From;
                    propWEobj.To = propWePrice.To;
                    _unitOfWork.PropertyWeekendPriceRepository.Update(propWEobj);
                }
            }
            _unitOfWork.Save();
            result = true;
            return result;
        }

        public bool UpdatePropFixPrice(PropertyFixedPricing propFixedPrice)
        {
            var result = false;
            var otherprice = "";
            if (propFixedPrice.PropFixedPriceId == 0)
            {

                if (propFixedPrice.OtherPrice != null)
                {
                    otherprice = propFixedPrice.OtherPrice.ToString();
                }

                _unitOfWork.PropFixedPriceRepository.Insert(new PropertyFixedPrice { StartDate = propFixedPrice.StartDate, EndDate = propFixedPrice.StopDate, PricePerAdult = Convert.ToDecimal(propFixedPrice.PricePerAdult), PricePerChild = Convert.ToDecimal(propFixedPrice.PricePerChild), CleaningFeeDaily = Convert.ToDecimal(propFixedPrice.CleaningFeeDaily), CleaningFeeWeek = Convert.ToDecimal(propFixedPrice.CleaningFeeWeekly), CleaningFeeMonth = Convert.ToDecimal(propFixedPrice.CleaningFeeMonthly), PricePerNight = Convert.ToDecimal(propFixedPrice.PricePerNight), PricePerWeek = Convert.ToDecimal(propFixedPrice.PricePerWeek), OneTimeFee = Convert.ToDecimal(propFixedPrice.PriceOneTime), PropertyId = propFixedPrice.PropertyId, Currency = propFixedPrice.CurrencyId.ToString(), OtherFee = otherprice, Comision = propFixedPrice.Comision });
            }
            else
            {
                var propfixedobj = _unitOfWork.PropFixedPriceRepository.GetByID(propFixedPrice.PropFixedPriceId);
                if (propfixedobj != null)
                {

                    propfixedobj.PricePerMonth = Convert.ToDecimal(propFixedPrice.PricePerMonth);
                    propfixedobj.PricePerNight = Convert.ToDecimal(propFixedPrice.PricePerNight);
                    propfixedobj.PricePerWeek = Convert.ToDecimal(propFixedPrice.PricePerWeek);
                    propfixedobj.CleaningFeeDaily = Convert.ToDecimal(propFixedPrice.CleaningFeeDaily);
                    propfixedobj.CleaningFeeMonth = Convert.ToDecimal(propFixedPrice.CleaningFeeMonthly);
                    propfixedobj.CleaningFeeWeek = Convert.ToDecimal(propFixedPrice.CleaningFeeWeekly);

                    propfixedobj.PricePerAdult = Convert.ToDecimal(propFixedPrice.PricePerAdult);
                    propfixedobj.PricePerChild = Convert.ToDecimal(propFixedPrice.PricePerChild);

                    if (propFixedPrice.OtherPrice != null)
                    {
                        propfixedobj.OtherFee = propFixedPrice.OtherPrice.ToString();
                    }
                    else
                    {
                        propfixedobj.OtherFee = otherprice;
                    }

                    propfixedobj.StartDate = propFixedPrice.StartDate;
                    propfixedobj.EndDate = propFixedPrice.StopDate;
                    propfixedobj.OneTimeFee = Convert.ToDecimal(propFixedPrice.PriceOneTime);
                    propfixedobj.Comision = propFixedPrice.Comision;
                    propfixedobj.Currency = propFixedPrice.CurrencyId.ToString();
                    _unitOfWork.PropFixedPriceRepository.Update(propfixedobj);
                }
            }
            _unitOfWork.Save();
            result = true;
            return result;
        }

        public bool UpdateTransferProperty(PropertyTransfer propTransfer)
        {
            var result = false;
            var propRmTransfer = _unitOfWork.PropertyRMMapRepository.Get(m => m.PropertyId == propTransfer.PropertyId);
            if (propRmTransfer != null)
            {
                propRmTransfer.LoginId = propTransfer.RmId;
                _unitOfWork.PropertyRMMapRepository.Update(propRmTransfer);
                _unitOfWork.Save();
                return true;
            }
            return result;
        }

        public bool PropertyAprrovalRequest(PropertyNotification notification)
        {
            var result = false;
            var propDelete = _unitOfWork.PropertyRepository.Get(m => m.Id == notification.PropertyId);
            if (propDelete != null)
            {
                propDelete.SendApprovedRequest = true;
                _unitOfWork.PropertyRepository.Update(propDelete);
                _unitOfWork.Save();
                return true;
            }
            return result;
        }
        public bool PropertyDeleteRequest(PropertyNotification notification)
        {
            var result = false;
            var propDelete = _unitOfWork.PropertyRepository.Get(m => m.Id == notification.PropertyId);
            if (propDelete != null)
            {
                propDelete.SendDeleteRequest = true;
                _unitOfWork.PropertyRepository.Update(propDelete);
                _unitOfWork.Save();
                return true;
            }
            return result;
        }

        public AdminHomeViewModel GetApprovedWaitingProperty()
        {
            var adminHomeVm = new AdminHomeViewModel();
            adminHomeVm.propertyListVm = _property.GetPropertyList().Where(m => !m.IsApproved & m.WaitingForApproval && !m.IsApproved).ToList();
            return adminHomeVm;
        }

        public AdminHomeViewModel GetDeleteRequestProperty()
        {
            var adminHomeVm = new AdminHomeViewModel();
            adminHomeVm.propertyListVm = _property.GetPropertyList().Where(m => !m.IsApproved & m.WaitingForDeletion).ToList();
            return adminHomeVm;
        }

        public bool ApprovedProperty(PropertyNotification notification)
        {
            var result = false;
            var propDelete = _unitOfWork.PropertyRepository.Get(m => m.Id == notification.PropertyId);
            if (propDelete != null)
            {
                propDelete.IsApproved = true;
                propDelete.SendApprovedRequest = false;
                _unitOfWork.PropertyRepository.Update(propDelete);
                _unitOfWork.Save();
                return true;
            }
            return result;
        }

    }
}

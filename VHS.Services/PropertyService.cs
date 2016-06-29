using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VHS.Interface;
using VHS.Repository;
using VHS.Services.Models;
using System.Transactions;
using VHS.Services.ViewModel;
using VHS.Core;

namespace VHS.Services
{
    public class PropertyService : IProperty
    {
        private readonly UnitOfWork _unitOfWork;
        public PropertyService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public bool AddProperty(Models.Property property, List<HttpPostedFileBase> file)
        {
            var result = false;
            //using (var tranaction = new TransactionScope())
            //{


            var propertObj = new Core.Property();
            propertObj.Title = property.Title;

            propertObj.NumberOfBathRoom = property.NoOfBathrooms;
            propertObj.NumberOfGuest = property.NoOfGuests;
            propertObj.NumberOfRooms = property.NoOfRooms;
            propertObj.Price = property.Price;
            propertObj.ListedId = property.ListById;
            propertObj.CategoryId = property.CategoryId;
            propertObj.IsApproved = false;
            propertObj.LoginId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            _unitOfWork.PropertyRepository.Insert(propertObj);
            _unitOfWork.Save();
            //Create Property Address:-
            var propAddressObj = new Core.PropertyAddress();
            propAddressObj.PropertyId = propertObj.Id;
            propAddressObj.Address = property.Address;
            propAddressObj.City = property.City;
            propAddressObj.Country = property.Country;
            propAddressObj.ZipCode = property.ZipCode;
            propAddressObj.Email = property.Email;
            propAddressObj.ContactNo = property.ContactNo;
            _unitOfWork.PropertyAddressRepository.Insert(propAddressObj);
            _unitOfWork.Save();
            //Create Property Image:-
            if (file.Count > 0)
            {
                foreach (var item in file)
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

                //}
                //tranaction.Complete();
                //tranaction.Dispose();
                result = true;
            }



            return result;
        }

        public IList<PropertyDisplayViewModel> GetProperties(SearchPropertyModel searchModel)
        {
            IList<PropertyDisplayViewModel> models = new List<PropertyDisplayViewModel>();
            searchModel.PropertyUID = string.IsNullOrEmpty(searchModel.PropertyUID) ? string.Empty : searchModel.PropertyUID;
            var propertyModel = _unitOfWork.GetProperties(searchModel.Query,searchModel.Region, searchModel.Guest, searchModel.PropertyUID);
            if (propertyModel != null)
                foreach (var model in propertyModel)
                    models.Add(new PropertyDisplayViewModel { Id = model.Id, RegionId = model.RegionId, Title = model.Title, Rating = model.Rating, CoverImage = model.CoverImage, Category = model.Category, Price = model.Price, PersonPerRoom = Convert.ToString(model.Bedroom), GuestCount = model.GuestCount });

            return models;
        }


        public PropertyDisplayViewModel GetPropertyDisplayModel(int? id)
        {
            if (id == null) return null;
            var propertyViemodle = new PropertyDisplayViewModel();

            var propertyModel = _unitOfWork.GetPropertyDetails(id);
            propertyViemodle.Id = propertyModel.Id;
            propertyViemodle.CoverImage = propertyModel.CoverImage;
            propertyViemodle.GalaryImages = !string.IsNullOrEmpty(propertyModel.GalaryImage) ? propertyModel.GalaryImage.Split(',') : null;
            propertyViemodle.Desc = propertyModel.Desc;
            propertyViemodle.CheckIn = propertyModel.CheckIn;
            propertyViemodle.CheckOut = propertyModel.CheckOut;
            propertyViemodle.IsPetAllowed = propertyModel.IsPetAllowed == "1" ? "Yes" : "No";
            propertyViemodle.IsSmokingAllowed = propertyModel.IsSmokingAllowed == "1" ? "Yes" : "No";
            propertyViemodle.IsWheelchairAccessible = propertyModel.IsWheelchairAccessible == "1" ? "Yes" : "No";
            propertyViemodle.IsFamilyKidFriendly = propertyModel.IsFamilyKidFriendly == "1" ? "Yes" : "No";
            propertyViemodle.IsDrinkingAllowed = propertyModel.IsDrinkingAllowed == "1" ? "Yes" : "No";
            propertyViemodle.PersonPerRoom = propertyModel.PersonPerRoom.ToString();
            propertyViemodle.City = propertyModel.City;
            propertyViemodle.Country = propertyModel.Country;
            propertyViemodle.Category = propertyModel.Category;
            propertyViemodle.Price = propertyModel.Price;
            propertyViemodle.Title = propertyModel.Title;
            propertyViemodle.CoverImage = propertyModel.CoverImage;
            propertyViemodle.Category = propertyModel.Category;
            propertyViemodle.Price = propertyModel.Price;
            propertyViemodle.PersonPerRoom = Convert.ToString(propertyModel.Bedroom);
            propertyViemodle.GuestCount = propertyModel.GuestCount;
            propertyViemodle.Rating = GetPropertyRating(propertyModel.Rating);
            propertyViemodle.General = !string.IsNullOrEmpty(propertyModel.General) ? propertyModel.General.Split(',').ToList() : new List<string>();
            propertyViemodle.SleepingArrangments = !string.IsNullOrEmpty(propertyModel.Sleeping) ? propertyModel.Sleeping.Split(',').ToList() : new List<string>();
            propertyViemodle.EntertainmentElectronic = !string.IsNullOrEmpty(propertyModel.Entertainment) ? propertyModel.Entertainment.Split(',').ToList() : new List<string>();
            propertyViemodle.Outdoor = !string.IsNullOrEmpty(propertyModel.Outdoor) ? propertyModel.Outdoor.Split(',').ToList() : new List<string>();
            propertyViemodle.Parking = !string.IsNullOrEmpty(propertyModel.Parking) ? propertyModel.Parking.Split(',').ToList() : new List<string>();
            propertyViemodle.Bathroom = !string.IsNullOrEmpty(propertyModel.Bathroom) ? propertyModel.Bathroom.Split(',').ToList() : new List<string>();
            propertyViemodle.Kitchen = !string.IsNullOrEmpty(propertyModel.Kitchen) ? propertyModel.Kitchen.Split(',').ToList() : new List<string>();
            propertyViemodle.MaxGuestCount = propertyModel.MaxGuestCount;
            propertyViemodle.PricePerAdult = propertyModel.PricePerAdult;
            propertyViemodle.PricePerChild = propertyModel.PricePerChild;
            propertyViemodle.CancellationPolicy = propertyModel.CancellationPolicy;
            propertyViemodle.MininumStay = propertyModel.MininumStay;
            propertyViemodle.RegionId = propertyModel.RegionId;
            //Set proprtyId for Booking Check Avalibility
            var propertyBooking = new Models.PropertyBooking();
            propertyBooking.PropertyId = (int)id;
            propertyViemodle.objPropertyBooking = propertyBooking;

            return propertyViemodle;
        }

        private string GetPropertyRating(string rating)
        {
            if (string.IsNullOrEmpty(rating)) return string.Empty;

            switch (rating)
            {
                case "1":
                    return "3";
                case "2":
                    return "3.5";
                case "3":
                    return "4";
                case "4":
                    return "4.5";
                case "5":
                    return "5";
                default:
                    return string.Empty;
            }
        }

        public List<PropertyViewModel> GetPropertyList()
        {
            var propertyList = new List<PropertyViewModel>();

            var propListObj = _unitOfWork.PropertyRepository.GetMany(x => x.IsActive);
            if (propListObj.Count() > 0)
            {
                foreach (var item in propListObj)
                {
                    propertyList.Add(new PropertyViewModel { PropertyId = item.Id, PropertyName = item.Title, PropertImageList = GetPropertyImage(item.Id), ShortInfo = GetShortInfo(item.CategoryId, item.Id), IsAssigned = item.IsAssigned, WaitingForApproval = item.SendApprovedRequest, WaitingForDeletion = item.SendDeleteRequest });
                }
            }
            return propertyList;
        }
        private List<ImageViewModel> GetPropertyImage(int propertyId)
        {
            var imageList = new List<ImageViewModel>();
            var propertImageMap = _unitOfWork.PropertyImageMapRepository.GetMany(m => m.PropertyId == propertyId).ToList();
            if (propertImageMap.Count > 0)
            {
                foreach (var item in propertImageMap)
                {
                    imageList.Add(new ImageViewModel { ImageId = item.ImageId, ImageName = _unitOfWork.ImageRepository.GetByID(item.ImageId).Name });
                }

            }
            return imageList;
        }
        private string GetShortInfo(int CategoryId, int propertyId)
        {
            string info = "";
            var categoryName = _unitOfWork.PropertyCategoryRepository.GetByID(CategoryId).CategoryName;
            var cityName = _unitOfWork.PropertyAddressRepository.Get(m => m.PropertyId == propertyId);
            if (cityName != null)
            {
                info = categoryName + "," + cityName.City;
            }
            return info;
        }

        public List<string> GetPropertyAutocompleteHelp(string query, string region)
        {
            int regionId = 0;
            if (region == "India") regionId = 1;
            else if (region == "Spain") regionId = 2;
            return _unitOfWork.GetPropertyAutocompleteHelp(query, regionId);
        }
    }
}

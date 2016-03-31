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

namespace VHS.Services
{
    public class PropertyService : IProperty
    {
        private readonly UnitOfWork _unitOfWork;
        public PropertyService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public bool AddProperty(Property property, List<HttpPostedFileBase> file)
        {
            var result = false;
            using (var tranaction = new TransactionScope())
            {


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

                }
                tranaction.Complete();
                tranaction.Dispose();
                result = true;
            }



            return result;
        }

        public IList<PropertyDisplayViewModel> GetAllProperty()
        {
            IList<PropertyDisplayViewModel> models = new List<PropertyDisplayViewModel>();

            var properties = _unitOfWork.PropertyRepository.GetMany(x => x.IsApproved && x.IsActive);

            if(properties != null && properties.Count() > 0)
            {
                foreach (var property in properties)
                {
                    var id = property.Id;

                    var propertyViemodle = new PropertyDisplayViewModel();
                    IList<string> galaryImages = new List<string>();

                    if (_unitOfWork.PropCoverPhotoRepository.GetMany(x => x.PropertyId == id).Any())
                    {
                        int coverImageId = _unitOfWork.PropCoverPhotoRepository.GetMany(x => x.PropertyId == id).FirstOrDefault().ImageId;
                        propertyViemodle.CoverImage = coverImageId != 0 ? _unitOfWork.ImageRepository.GetByID(coverImageId).Name : string.Empty;
                    }
                    if (_unitOfWork.PropertyGallaryRepository.GetMany(x => x.PropertyId == id).Any())
                    {
                        var imageids = _unitOfWork.PropertyGallaryRepository.GetMany(x => x.PropertyId == id).Select(X => X.ImageId);
                        if (imageids != null)
                            foreach (var imageid in imageids)
                                galaryImages.Add(_unitOfWork.ImageRepository.GetByID(imageid).Name);
                        propertyViemodle.GalaryImages = galaryImages.ToArray();
                    }
                    if (_unitOfWork.PropertyAdditionalRepository.GetMany(x => x.PropertyId == id).Any())
                    {
                        var additionnalDetails = _unitOfWork.PropertyAdditionalRepository.GetMany(x => x.PropertyId == id).FirstOrDefault();
                        propertyViemodle.Desc = additionnalDetails.PropDescription;
                        propertyViemodle.CheckIn = additionnalDetails.CheckInTime;
                        propertyViemodle.CheckOut = additionnalDetails.CheckOutTime;
                        propertyViemodle.IsPetAllowed = additionnalDetails.IsPetsAllowed == "1" ? "Yes" : "No";
                        propertyViemodle.IsSmokingAllowed = additionnalDetails.IsSmokingAllowed == "1" ? "Yes" : "No";
                        propertyViemodle.IsWheelchairAccessible = additionnalDetails.IsWheelChairAccess == "1" ? "Yes" : "No";
                        propertyViemodle.IsFamilyKidFriendly = additionnalDetails.IsFamKidFriendAllowed == "1" ? "Yes" : "No";
                        propertyViemodle.IsDrinkingAllowed = additionnalDetails.IsDrinikingAllowed == "1" ? "Yes" : "No";
                        propertyViemodle.PersonPerRoom = additionnalDetails.PersonPerRoom.ToString();
                        propertyViemodle.Title = property.Title;
                    }

                    var categoryId = _unitOfWork.PropertyRepository.GetByID(id) != null ? _unitOfWork.PropertyRepository.GetByID(id).CategoryId : 0;

                    if (categoryId != 0)
                        propertyViemodle.Category = _unitOfWork.PropertyCategoryRepository.GetFirst(x => x.Id == categoryId).CategoryName;

                    if (_unitOfWork.PropFixedPriceRepository.GetMany(x => x.PropertyId == id).Any())
                        propertyViemodle.Price = _unitOfWork.PropFixedPriceRepository.GetMany(x => x.PropertyId == id).FirstOrDefault().PricePerNight;

                    if (_unitOfWork.PropertyAddressRepository.GetMany(x => x.PropertyId == id).Any())
                    {
                        var address = _unitOfWork.PropertyAddressRepository.GetMany(x => x.PropertyId == id).FirstOrDefault();
                        propertyViemodle.City = address.City;
                        propertyViemodle.Address = address.Address;
                    }

                    models.Add(propertyViemodle);

                }

            }
            return models;
           
        }

        public PropertyDisplayViewModel GetPropertyDisplayModel(int? id)
        {
            if (id == null) return null;
            var propertyViemodle = new PropertyDisplayViewModel();
            IList<string> galaryImages = new List<string>();
            if (_unitOfWork.PropCoverPhotoRepository.GetMany(x => x.PropertyId == id).Any())
            {
                int coverImageId = _unitOfWork.PropCoverPhotoRepository.GetMany(x => x.PropertyId == id).FirstOrDefault().ImageId;
                propertyViemodle.CoverImage = coverImageId != 0 ? _unitOfWork.ImageRepository.GetByID(coverImageId).Name : string.Empty;
            }
            if (_unitOfWork.PropertyGallaryRepository.GetMany(x => x.PropertyId == id).Any())
            {
                var imageids = _unitOfWork.PropertyGallaryRepository.GetMany(x => x.PropertyId == id).Select(X => X.ImageId);
                if (imageids != null)
                    foreach (var imageid in imageids)
                        galaryImages.Add(_unitOfWork.ImageRepository.GetByID(imageid).Name);
                propertyViemodle.GalaryImages = galaryImages.ToArray();
            }
            if (_unitOfWork.PropertyAdditionalRepository.GetMany(x => x.PropertyId == id).Any())
            {
                var additionnalDetails = _unitOfWork.PropertyAdditionalRepository.GetMany(x => x.PropertyId == id).FirstOrDefault();
                propertyViemodle.Desc = additionnalDetails.PropDescription;
                propertyViemodle.CheckIn = additionnalDetails.CheckInTime;
                propertyViemodle.CheckOut = additionnalDetails.CheckOutTime;
                propertyViemodle.IsPetAllowed = additionnalDetails.IsPetsAllowed == "1" ? "Yes" : "No";
                propertyViemodle.IsSmokingAllowed = additionnalDetails.IsSmokingAllowed == "1" ? "Yes" : "No";
                propertyViemodle.IsWheelchairAccessible = additionnalDetails.IsWheelChairAccess == "1" ? "Yes" : "No";
                propertyViemodle.IsFamilyKidFriendly = additionnalDetails.IsFamKidFriendAllowed == "1" ? "Yes" : "No";
                propertyViemodle.IsDrinkingAllowed = additionnalDetails.IsDrinikingAllowed == "1" ? "Yes" : "No";
                propertyViemodle.PersonPerRoom = additionnalDetails.PersonPerRoom.ToString();
            }

            var categoryId = _unitOfWork.PropertyRepository.GetByID(id) != null ? _unitOfWork.PropertyRepository.GetByID(id).CategoryId : 0;

            if (categoryId != 0)
                propertyViemodle.Category = _unitOfWork.PropertyCategoryRepository.GetFirst(x => x.Id == categoryId).CategoryName;

            if (_unitOfWork.PropFixedPriceRepository.GetMany(x => x.PropertyId == id).Any())
                propertyViemodle.Price =  _unitOfWork.PropFixedPriceRepository.GetMany(x => x.PropertyId == id).FirstOrDefault().PricePerNight;

            if (_unitOfWork.PropertyAddressRepository.GetMany(x => x.PropertyId == id).Any())
                propertyViemodle.City = _unitOfWork.PropertyAddressRepository.GetMany(x => x.PropertyId == id).FirstOrDefault().City;
            
            return propertyViemodle;
        }

        public List<PropertyViewModel> GetPropertyList()
        {
            var propertyList = new List<PropertyViewModel>();

            var propListObj = _unitOfWork.PropertyRepository.GetAll();
            if (propListObj.Count() > 0)
            {
                foreach (var item in propListObj)
                {
                    propertyList.Add(new PropertyViewModel { PropertyId = item.Id, PropertyName = item.Title, PropertImageList = GetPropertyImage(item.Id), ShortInfo = GetShortInfo(item.CategoryId, item.Id) });
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
            var cityName = _unitOfWork.PropertyAddressRepository.GetFirst(m => m.PropertyId == propertyId).City;
            info = categoryName + "," + cityName;
            return info;
        }
    }
}

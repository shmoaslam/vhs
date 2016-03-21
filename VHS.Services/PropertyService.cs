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
                propertObj.Email = property.Email;
                propertObj.NumberOfBathRoom = property.NoOfBathrooms;
                propertObj.NumberOfGuest = property.NoOfGuests;
                propertObj.NumberOfRooms = property.NoOfRooms;
                propertObj.Price = property.Price;
                propertObj.ListedId = property.ListById;
                propertObj.CategoryId = property.CategoryId;
                propertObj.IsApproved = false;
                propertObj.LoginId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                propertObj.ContactNo = property.ContactNo;
                _unitOfWork.PropertyRepository.Insert(propertObj);
                _unitOfWork.Save();
                //Create Property Address:-
                var propAddressObj = new Core.PropertyAddress();
                propAddressObj.PropertyId = propertObj.Id;
                propAddressObj.Address = property.Address;
                propAddressObj.City = property.City;
                propAddressObj.Country = property.Country;
                propAddressObj.ZipCode = property.ZipCode;
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

        public List<PropertyViewModel> GetPropertyList()
        {
            var propertyList = new List<PropertyViewModel>();

            var propListObj = _unitOfWork.PropertyRepository.GetAll();
            if (propListObj.Count() > 0)
            {
                foreach (var item in propListObj)
                {
                    propertyList.Add(new PropertyViewModel { PropertyId = item.Id, PropertyName = item.Title, PropertImageList = GetPropertyImage(item.Id),ShortInfo= GetShortInfo(item.CategoryId,item.Id )});
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

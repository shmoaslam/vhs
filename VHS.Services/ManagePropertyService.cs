﻿using System;
using System.Collections.Generic;
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
            var propertyList = _property.GetPropertyList();
            var rmPropMapList = GetPropRmMap();
            var result = (from prop in propertyList
                          join rpm in rmPropMapList on prop.PropertyId equals rpm.ProprtyId into s
                          from spm in s.DefaultIfEmpty()
                          select new PropertyViewModel { PropertyId = prop.PropertyId, PropertyName = prop.PropertyName, ShortInfo = prop.ShortInfo, PropertImageList = prop.PropertImageList, RmId = spm == null ? 0 : spm.RMId }).ToList();
            manageProperty.proppertyVMList = result;
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
            propertyEditViewModel.propertyPhoto = GetPropertyApperance(PropertyId);
            propertyEditViewModel.propertyTravelAmbassdor = GetPropertyTravelAmbassReview(PropertyId);
            propertyEditViewModel.propertyTransfer = GetPropertyTransferDetail(PropertyId);
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
                if (propGenralIngoobj.PricePerNight != null)
                {
                    propertyGeneralInfo.PricePerNight = propGenralIngoobj.PricePerNight;
                }
                if (propGenralIngoobj.PricePerWeek != null)
                {
                    propertyGeneralInfo.PricePerWeek = propGenralIngoobj.PricePerWeek;
                }
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
            return propertyGeneralInfo;
        }
        public PropertyAdditionalInfoModel GetPropertyAdditionalInfo(int propertyId)
        {
            var propertyAdditionalInfo = new PropertyAdditionalInfoModel();
            propertyAdditionalInfo.BathRoomsList = GetAllBathRooms(propertyId);
            return propertyAdditionalInfo;
        }
        public PropertyPhoto GetPropertyApperance(int PropertyId)
        {
            var propertyPhoto = new PropertyPhoto();
            return propertyPhoto;
        }
        public PropertyTravelAmbassador GetPropertyTravelAmbassReview(int PropertyId)
        {
            var propertyTravleAmbassReview = new PropertyTravelAmbassador();
            return propertyTravleAmbassReview;
        }
        public PropertyTransfer GetPropertyTransferDetail(int PropertyId)
        {
            var propertyTransfer = new PropertyTransfer();
            return propertyTransfer;
        }

        //Update Property Detail:-
        public bool UpdateGeneralInfo(PropertyGeneralInfo propGeneralInfo, List<HttpPostedFileBase> file)
        {
            var result = false;
            //using (var tranaction = new TransactionScope())
            //{
            var propertObj = _unitOfWork.PropertyRepository.GetByID(propGeneralInfo.PropertyId);

            // var propertObj = new Core.Property();
            propertObj.Title = propGeneralInfo.Title;

            propertObj.NumberOfBathRoom = propGeneralInfo.NoOfBathrooms;
            propertObj.NumberOfGuest = propGeneralInfo.NoOfGuests;
            propertObj.NumberOfRooms = propGeneralInfo.NoOfRooms;
            propertObj.Price = propGeneralInfo.Price;
            propertObj.ListedId = propGeneralInfo.ListById;
            propertObj.CategoryId = propGeneralInfo.CategoryId;
            propertObj.IsApproved = false;
            // propertObj.LoginId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
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

                    var imgPropMap = _unitOfWork.PropertyImageMapRepository.GetSingle(m => m.PropertyId == propGeneralInfo.PropertyId); ;
                    imgPropMap.ImageId = imageObj.ImageId;
                    _unitOfWork.PropertyImageMapRepository.Update(imgPropMap);
                    _unitOfWork.Save();

                }

                //}
                //tranaction.Complete();
                //tranaction.Dispose();
                result = true;
            }



            return result;
        }
        public bool UpdateAdditionalInfo(PropertyAdditionalInfoModel propAdditionalInfoInfo)
        {
            var result = false;
            return result;
        }
        public bool UpdateAppearanceSetting(PropertyPhoto propPhoto, List<HttpPostedFileBase> ImageCoverPhoto, List<HttpPostedFileBase> ImageGallaryPhoto)
        {
            var result = false;
            return result;
        }
        public bool UpdateTravelAmbassador(PropertyTravelAmbassador propTravelAmbass)
        {
            var result = false;
            return result;
        }
        public bool UpdateTransferProperty(PropertyTransfer propTransfer)
        {
            var result = false;
            return result;
        }
        public bool DeleteProperty(int PropertyId)
        {
            var result = false;
            return result;
        }

        public List<PropertyViewModel> GetPropertyForManage(int rmID)
        {
            var rmHomeVm = new List<PropertyViewModel>();
            var propertyRmList = GetPropRmMap();
            var propertyList = _property.GetPropertyList();
            if (rmID == 0)
            {
                var result = (from pr in propertyRmList
                              join pl in propertyList on pr.ProprtyId equals pl.PropertyId
                              select new PropertyViewModel { PropertyId = pl.PropertyId, PropertyName = pl.PropertyName, ShortInfo = pl.ShortInfo, PropertImageList = pl.PropertImageList }).ToList();
                return result;

            }
            else
            {
                var result = (from pr in propertyRmList
                              join pl in propertyList on pr.ProprtyId equals pl.PropertyId
                              where (pr.RMId == rmID)
                              select new PropertyViewModel { PropertyId = pl.PropertyId, PropertyName = pl.PropertyName, ShortInfo = pl.ShortInfo, PropertImageList = pl.PropertImageList }).ToList();
                return result;
            }


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
        public IEnumerable<ViewModel.BathRommsModel> GetAllParking(int propertyId)
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
        public IEnumerable<ViewModel.BathRommsModel> GetAllSleepingArrangment(int propertyId)
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
        public IEnumerable<ViewModel.BathRommsModel> GetAllKitchen(int propertyId)
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
        public IEnumerable<ViewModel.BathRommsModel> GetAllGeneral(int propertyId)
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
        public IEnumerable<ViewModel.BathRommsModel> GetAllEnterTaimentElec(int propertyId)
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
        public IEnumerable<ViewModel.BathRommsModel> GetAllOutdoorFacilities(int propertyId)
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
    }
}

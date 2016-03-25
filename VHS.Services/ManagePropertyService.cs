using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                          select new PropertyViewModel {PropertyId=prop.PropertyId,PropertyName=prop.PropertyName,ShortInfo=prop.ShortInfo,PropertImageList=prop.PropertImageList,RmId=spm.RMId}).ToList();
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Interface;
using VHS.Repository;
using VHS.Services.Interface;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public class AdminHomeService : IAdminHome
    {
        private readonly UnitOfWork _unitOfWork;
        private IProperty _property;
        private IManageProperty _manageProperty;
        public AdminHomeService(IProperty property, IManageProperty manageProperty)
        {
            _property = property;
            _manageProperty = manageProperty;
        }
        public AdminHomeViewModel GetAddedProperty()
        {
            var adminHomeVm = new AdminHomeViewModel();
            adminHomeVm.propertyListVm = _property.GetPropertyList();
            return adminHomeVm;
        }
        public RmHomeViewModel GetAssignedPropertyRm(int rmId)
        {
            var rmHomeVm = new RmHomeViewModel();
            var propertyRmList = _manageProperty.GetPropRmMap();
            var propertyList = _property.GetPropertyList();
            var result = (from pr in propertyRmList
                          join pl in propertyList on pr.ProprtyId equals pl.PropertyId
                          where (pr.RMId == rmId)
                          select new PropertyViewModel { PropertyId = pl.PropertyId, PropertyName = pl.PropertyName, ShortInfo = pl.ShortInfo, PropertImageList = pl.PropertImageList }).ToList();

            rmHomeVm.assignedPropertyListVm = result;
            return rmHomeVm;
        }

    }
}

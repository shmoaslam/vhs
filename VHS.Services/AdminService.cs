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
    public class AdminService : IAdminHome
    {
        private readonly UnitOfWork _unitOfWork;
        private IProperty _property;
        private IManageProperty _manageProperty;
        public AdminService(IProperty property, IManageProperty manageProperty)
        {
            _unitOfWork = new UnitOfWork();
            _property = property;
            _manageProperty = manageProperty;
        }
        public AdminHomeViewModel GetAddedProperty()
        {
            var adminHomeVm = new AdminHomeViewModel();
            adminHomeVm.propertyListVm = _property.GetPropertyList().Where(m => m.IsApproved == true).ToList();
            return adminHomeVm;
        }
        public RmHomeViewModel GetAssignedPropertyRm(int rmId)
        {
            var rmHomeVm = new RmHomeViewModel();
            var propDisplayList = new List<PropertyViewModel>();
            var propList = _unitOfWork.GetPropertyListForAdmin(rmId);

            foreach (var item in propList)
                propDisplayList.Add(new PropertyViewModel { PropertyId = item.Id, PropertyName = item.Name, ShortInfo = item.ShortInfo, PropertImage = item.PropertImage });

            rmHomeVm.assignedPropertyListVm = propDisplayList;
            return rmHomeVm;
        }

    }
}

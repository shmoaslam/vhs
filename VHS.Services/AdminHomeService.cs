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
        public AdminHomeService(IProperty property)
        {
            _property = property;
        }
        public AdminHomeViewModel GetAddedProperty()
        {
            var adminHomeVm = new AdminHomeViewModel();
            adminHomeVm.propertyListVm = _property.GetPropertyList();
            return adminHomeVm;
        }
    }
}

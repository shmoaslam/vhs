using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Repository;
using VHS.Services.Interface;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public class ManageRmService : IManageRm
    {
        private readonly UnitOfWork _unitOfWork;
        public ManageRmService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<RMViewModel> GetRmList()
        {
            var rmViewList = new List<RMViewModel>();
            var rmList = _unitOfWork.LoginRepository.GetMany(m => m.TypeId == Convert.ToInt32(UserTypeEnum.RM)).ToList();
            foreach (var item in rmList)
            {
                rmViewList.Add(new RMViewModel { RMId = item.LoginId, RMName = item.Name, IsApproved = item.IsActive });
            }
            return rmViewList;

        }

    }
}

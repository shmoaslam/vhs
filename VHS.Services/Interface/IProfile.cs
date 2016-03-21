using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VHS.Services.ViewModel;

namespace VHS.Interface
{
    public interface IProfile
    {
        ProfileViewModel GetUserDetail(int loginId);
        bool UpdateProfile(ProfileViewModel profilevm, int loginId);
        bool UpdateProfileAdditionalInfo(ProfileViewModel profilevm, int loginId, List<HttpPostedFileBase> Document);


    }
}

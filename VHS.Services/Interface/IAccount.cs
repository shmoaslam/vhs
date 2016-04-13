using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services;
using VHS.Services.Models;

namespace VHS.Interface
{
    public interface IAccount
    {
        UserInfo CheckLogin(LoginViewModel login);
        bool RegisterUser(RegisterViewModel login, int UserType);
        bool CheckEmailExist(string EmailId);
        UserInfo CheckAdminLogin(LoginViewModel login);
        RmCreatePassword RmAccountConfirmation(string token);
        bool RmAccountCreatePassword(RmCreatePassword rmchangePassword);
        UserInfo GetUserDetail(string emailId);
    }
}

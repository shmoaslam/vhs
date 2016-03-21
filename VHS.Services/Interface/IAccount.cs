using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services;

namespace VHS.Interface
{
    public interface IAccount
    {
        LoginViewModel CheckLogin(LoginViewModel login);
        bool RegisterUser(RegisterViewModel login ,int UserType);
        bool CheckEmailExist(string EmailId);
        LoginViewModel CheckAdminLogin(LoginViewModel login);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Core;
using VHS.Repository;
using VHS.Services.Interface;
using System.Configuration;
using System.Transactions;
using System.Web;
using VHS.Interface;

namespace VHS.Services
{
    public class AccountService : IAccount
    {
        private readonly UnitOfWork _unitOfWork;


        public AccountService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public LoginViewModel CheckLogin(LoginViewModel loginvm)
        {
            var loginvmobj = new LoginViewModel();
            var login = _unitOfWork.LoginRepository.Get(m => m.Email == loginvm.EmailId && m.Password == loginvm.Password && m.IsActive == true);
            if (login != null)
            {

                loginvmobj.LoginId = login.LoginId;
                if (login.Name != "")
                {
                    HttpContext.Current.Session["Name"] = login.Name.ToString();
                }
                else
                {
                    HttpContext.Current.Session["Name"] = login.Email.ToString();
                }

            }
            return loginvmobj;
        }
        public LoginViewModel CheckAdminLogin(LoginViewModel loginvm)
        {
            var loginvmobj = new LoginViewModel();
            var login = _unitOfWork.LoginRepository.Get(m => m.Email == loginvm.EmailId && m.Password == loginvm.Password && m.IsActive == true && m.TypeId == Convert.ToInt32(UserTypeEnum.Admin));
            if (login != null)
            {
                loginvmobj.LoginId = login.LoginId;
                HttpContext.Current.Session["Name"] = login.Name.ToString();
            }
            return loginvmobj;
        }
        public bool RegisterUser(RegisterViewModel register, int UserType)
        {
            var result = false;
            //using (var scope = new TransactionScope())
            //{
            //Create Login Detail:-
            UserLogin loginObj = new UserLogin();
            if (register.Name != null)
            {
                loginObj.Name = register.Name;
            }
            else
            {
                loginObj.Name = ""; ;
            }

            loginObj.Email = register.EmailId;
            loginObj.CreatedBy = 0;
            loginObj.UpdatedBy = 0;
            loginObj.Password = register.Password;
            loginObj.TypeId = UserType;
            loginObj.IsEmailVerified = false;
            _unitOfWork.LoginRepository.Insert(loginObj);
            _unitOfWork.Save();
            ////Create User Profile
            UserProfile userProfile = new UserProfile();
            userProfile.LoginId = loginObj.LoginId;
            userProfile.PrefMethodContact = "";
            userProfile.PrefCallTime = "";
            if (register.Mobile != null)
            {
                userProfile.Mobile = register.Mobile;
            }
            else
            {
                userProfile.Mobile = "";
            }

            userProfile.HomeTelephone = "";
            userProfile.WorkTelephone = "";
            userProfile.TravelPreferences = "";
            userProfile.IsVerified = false;
            _unitOfWork.UserProfileRepository.Insert(userProfile);
            _unitOfWork.Save();
            //scope.Complete();
            //Mail Send For Normal User registration and Also RM Registration:-
            if (UserType == Convert.ToInt32(UserTypeEnum.User))
            {

            }
            result = true;
            //}
            return result;
        }
        public bool CheckEmailExist(string EmailId)
        {
            bool flag = true;
            var logemailCheck = _unitOfWork.LoginRepository.GetMany(m => m.Email == EmailId).Any();
            if (logemailCheck)
            {
                flag = false;
            }
            return flag;
        }
    }
}

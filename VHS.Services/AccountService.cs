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
using VHS.Services.Models;
using VHS.Services.App_Code;

namespace VHS.Services
{
    public class AccountService : IAccount
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

        public AccountService(INotificationService notificationService)
        {
            _notificationService = notificationService;
            _unitOfWork = new UnitOfWork();
        }

        public UserInfo CheckLogin(LoginViewModel loginvm)
        {
            var userInfo = new UserInfo();
            var login = _unitOfWork.LoginRepository.Get(m => m.Email == loginvm.EmailId && m.Password == loginvm.Password && m.IsActive == true);
            if (login != null)
            {
                userInfo.LoginId = login.LoginId;
                userInfo.Email = login.Email;
                userInfo.UserType = login.TypeId;
                if (login.Name == "")
                {
                    userInfo.Name = login.Email;
                }
                else
                {
                    userInfo.Name = login.Name;
                }
            }
            return userInfo;
        }
        public UserInfo CheckAdminLogin(LoginViewModel loginvm)
        {
            var userInfo = new UserInfo();
            var login = _unitOfWork.LoginRepository.Get(m => m.Email == loginvm.EmailId && m.Password == loginvm.Password && m.IsActive == true && (m.TypeId == Convert.ToInt32(UserTypeEnum.Admin) || m.TypeId == Convert.ToInt32(UserTypeEnum.RM)));
            if (login != null)
            {
                userInfo.LoginId = login.LoginId;
                userInfo.Name = login.Name.ToString();
                userInfo.Email = login.Email;
                userInfo.UserType = login.TypeId;
            }
            return userInfo;
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
                if (UserType == 2)
                    loginObj.IsActive = false;
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
                _notificationService.UserRegistration(register.EmailId, register.Name);
            }
            if (UserType == Convert.ToInt32(UserTypeEnum.RM))
            {
                //call send email functionality for rm confirmation:-
                _notificationService.RmAccountCreation(register.EmailId, register.Name, loginObj.LoginId);
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

        public RmCreatePassword RmAccountConfirmation(string token)
        {
            var rmcreatePassword = new RmCreatePassword();
            var mailid = Security.Decrypt(token);
            var getmailId = _unitOfWork.MailLinkRepository.GetByID(Convert.ToInt32(mailid));
            if (getmailId != null)
            {
                rmcreatePassword.EmailId = getmailId.Email;
                rmcreatePassword.IsLinkUsed = getmailId.Linkused;
                rmcreatePassword.MailLinkId = getmailId.id;
            }
            return rmcreatePassword;
        }

        public bool RmAccountCreatePassword(RmCreatePassword rmchangePassword)
        {
            bool flag = false;
            var getdetail = _unitOfWork.LoginRepository.Get(m => m.Email == rmchangePassword.EmailId && m.IsActive == false);
            if (getdetail != null)
            {
                getdetail.Password = rmchangePassword.Password;
                getdetail.IsActive = true;
                getdetail.IsEmailVerified = true;
                _unitOfWork.LoginRepository.Update(getdetail);
                _unitOfWork.Save();
                var getmailId = _unitOfWork.MailLinkRepository.GetByID(Convert.ToInt32(rmchangePassword.MailLinkId));
                getmailId.Linkused = true;
                _unitOfWork.MailLinkRepository.Update(getmailId);
                _unitOfWork.Save();
                flag = true;
            }
            return flag;
        }


        public UserInfo GetUserDetail(string emailId)
        {
            var userInfo = new UserInfo();
            var login = _unitOfWork.LoginRepository.Get(m => m.Email == emailId && m.IsActive == true);
            if (login != null)
            {
                userInfo.LoginId = login.LoginId;
                userInfo.Name = login.Name.ToString();
                userInfo.Email = login.Email;
                userInfo.UserType = login.TypeId;
            }
            return userInfo;
        }

        public string GeneratePasswordResetToken(string email)
        {
            if (string.IsNullOrEmpty(email)) return string.Empty;
            var login = _unitOfWork.LoginRepository.Get(m => m.Email == email && m.IsActive == true);
            if (login != null)
            {
                var tokenExist = _unitOfWork.ResetPasswordTokenRepository.GetMany(x => x.Email == login.Email).Any();
                var returnToken = string.Empty;
                if(tokenExist)
                {
                    var token = _unitOfWork.ResetPasswordTokenRepository.GetSingle(x => x.Email == login.Email);
                    token.Token = Guid.NewGuid();
                    token.ExpirationDate = DateTime.Now.AddHours(24);
                    _unitOfWork.ResetPasswordTokenRepository.Update(token);
                    returnToken = token.Token.ToString();
                }
                else
                {
                    var resetToken = new ResetPasswordToken
                    {
                        Email = login.Email,
                        LoginId = login.LoginId,
                        Token = Guid.NewGuid(),
                        ExpirationDate = DateTime.Now.AddHours(24),
                    };
                    _unitOfWork.ResetPasswordTokenRepository.Insert(resetToken);
                    returnToken = resetToken.Token.ToString();
                }


                _unitOfWork.Save();

                return returnToken;

            }
            return string.Empty;
        }

        public void ResetPassword(string email, string password)
        {
            if (string.IsNullOrEmpty(email)) return;
            var login = _unitOfWork.LoginRepository.Get(m => m.Email == email && m.IsActive == true);
            if (login != null)
            {
                login.Password = password;

                _unitOfWork.LoginRepository.Update(login);

                _unitOfWork.Save();
            }
        }

        public bool CheckForgotPasswordEmailExists(string email)
        {
            return _unitOfWork.LoginRepository.GetMany(m => m.Email == email && m.IsActive).Any();
        }

        public string GetUserEmailFromToken(string code)
        {
            if (string.IsNullOrEmpty(code)) return string.Empty;

            var tokens = _unitOfWork.ResetPasswordTokenRepository.GetMany(x => x.Token.ToString() == code && x.ExpirationDate > DateTime.Now);

            if(tokens != null)
                return tokens.FirstOrDefault().Email;

            return string.Empty;
        }
    }
}

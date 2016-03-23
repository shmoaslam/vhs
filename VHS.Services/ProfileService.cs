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
using VHS.Services.ViewModel;
using VHS.Interface;
using System.IO;
using System.Web.Mvc;

namespace VHS.Services
{
    public class ProfileService : IProfile
    {
        private readonly UnitOfWork _unitOfWork;

        public ProfileService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public ProfileViewModel GetUserDetail(int loginId)
        {
            var profileObject = new ProfileViewModel();
            var loginUser = _unitOfWork.LoginRepository.GetByID(loginId);
            var userDetail = _unitOfWork.UserProfileRepository.GetByID(loginId);
            profileObject.Name = loginUser.Name;
            profileObject.EmailId = loginUser.Email;
            profileObject.Address = userDetail.Address;
            profileObject.City = userDetail.City;
            profileObject.HomeTelephone = userDetail.HomeTelephone;
            profileObject.Mobile = userDetail.Mobile;
            profileObject.PrefContactMethod = GetPreferedContactMethod();
            if (userDetail.PrefMethodContact != "")
            {
                profileObject.PrefContactId = Convert.ToInt32(userDetail.PrefMethodContact);
            }
            profileObject.PrefCalltime = GetCallTime();
            if (userDetail.PrefCallTime != "")
            {
                profileObject.CallTimeId = Convert.ToInt32(userDetail.PrefCallTime);
            }
            profileObject.Telephone = userDetail.Telephone;
            profileObject.WorkTelephone = userDetail.WorkTelephone;
            profileObject.ZipCode = userDetail.ZipCode;
            profileObject.Anniversary = userDetail.BirthDay;
            profileObject.Anniversary = userDetail.Anniversary;
            profileObject.IsVerified = userDetail.IsVerified;

            //Travel Preference:-
            profileObject.TravelPreferences = GetAllTravelPreference(loginId).ToList();
            return profileObject;
        }

        public bool UpdateProfile(ProfileViewModel profilevm, int loginId)
        {
            bool result = false;
            var loginUser = _unitOfWork.LoginRepository.GetByID(loginId);
            loginUser.Email = profilevm.EmailId;
            loginUser.Name = profilevm.Name;
            loginUser.Password = profilevm.Password;
            var userDetail = _unitOfWork.UserProfileRepository.GetByID(loginId);

            userDetail.Telephone = profilevm.Telephone;
            userDetail.Mobile = profilevm.Mobile;
            userDetail.HomeTelephone = profilevm.HomeTelephone;
            userDetail.Address = profilevm.Address;
            userDetail.City = profilevm.City;
            userDetail.ZipCode = profilevm.ZipCode;
            _unitOfWork.LoginRepository.Update(loginUser);
            _unitOfWork.Save();
            result = true;

            return result;

        }

        public bool UpdateProfileAdditionalInfo(ProfileViewModel profilevm, int loginId, List<HttpPostedFileBase> Document)
        {
            bool result = false;

            var userAdditionalDetail = _unitOfWork.UserProfileRepository.GetByID(loginId);

            userAdditionalDetail.BirthDay = profilevm.BirthDay;
            userAdditionalDetail.Anniversary = profilevm.Anniversary;
            userAdditionalDetail.WorkTelephone = profilevm.WorkTelephone;
            userAdditionalDetail.PrefMethodContact = profilevm.PrefContactId.ToString();
            userAdditionalDetail.PrefCallTime = profilevm.CallTimeId.ToString();
            _unitOfWork.UserProfileRepository.Update(userAdditionalDetail);


            if (Document.Count > 0)
            {
                foreach (var item in Document)
                {
                    var docfilelist = _unitOfWork.DocumentRepository.GetMany(m => m.LoginId == loginId).ToList();
                    if (docfilelist.Count > 0)
                    {
                        if (item != null && item.ContentLength > 0)
                        {
                            docfilelist[0].FileName = item.FileName.ToString();
                            string extension = Path.GetExtension(item.FileName).ToString();
                            string filename = Path.GetFileNameWithoutExtension(item.FileName) + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadFile/Document/"), filename);
                            item.SaveAs(path);
                            _unitOfWork.DocumentRepository.Update(docfilelist[0]);
                            _unitOfWork.Save();
                        }

                    }
                    else
                    {
                        if (item != null && item.ContentLength > 0)
                        {
                            var docObj = new Core.Document();
                            docObj.FileName = item.FileName.ToString();
                            string extension = Path.GetExtension(item.FileName).ToString();
                            string filename = Path.GetFileNameWithoutExtension(item.FileName) + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadFile/Document/"), filename);
                            item.SaveAs(path);
                            docObj.LoginId = loginId;
                            _unitOfWork.DocumentRepository.Insert(docObj);
                            _unitOfWork.Save();
                        }
                    }

                }

            }
            //Update Travel preferneces:-
            if(profilevm.TravelPreferencesId.Count() > 0)
            {
                _unitOfWork.UserTravelPrefMapRepository.Delete(m => m.LoginId == loginId);
                foreach (var travelPref in profilevm.TravelPreferencesId)
                {
                    _unitOfWork.UserTravelPrefMapRepository.Insert(new UserTravelPrefMapping { TravelPrefId = travelPref, LoginId = loginId });
                }
                _unitOfWork.Save();
            }

            //if (profilevm.TravelPreferenceObj.Count() > 0)
            //{
            //    var travelprefList = _unitOfWork.UserTravelPrefMapRepository.GetMany(m => m.LoginId == loginId).ToList();
            //    if (travelprefList.Count > 0)
            //    {
            //        var flag = false;
            //        foreach (var item in profilevm.TravelPreferenceObj)
            //        {

            //            foreach (var travelpref in travelprefList)
            //            {
            //                if (item.id == travelpref.TravelPrefId)
            //                {
            //                    flag = true;
            //                }

            //            }
            //            if (true)
            //            {
            //                var userPrefmap = new Core.UserTravelPrefMapping();
            //                userPrefmap.TravelPrefId = item.id;
            //                userPrefmap.LoginId = loginId;
            //                _unitOfWork.UserTravelPrefMapRepository.Update(userPrefmap);
            //                _unitOfWork.Save();
            //            }
            //            else
            //            {
            //                var userPrefmap = new Core.UserTravelPrefMapping();
            //                userPrefmap.TravelPrefId = item.id;
            //                userPrefmap.LoginId = loginId;
            //                _unitOfWork.UserTravelPrefMapRepository.Update(userPrefmap);
            //                _unitOfWork.Save();
            //            }
            //            flag = false;
            //        }

            //    }
            //    else
            //    {
            //        foreach (var item in profilevm.TravelPreferenceObj)
            //        {
            //            var userPrefmap = new Core.UserTravelPrefMapping();
            //            userPrefmap.TravelPrefId = item.id;
            //            userPrefmap.LoginId = loginId;
            //            _unitOfWork.UserTravelPrefMapRepository.Update(userPrefmap);
            //            _unitOfWork.Save();
            //        }

            //    }
            //}


            _unitOfWork.UserProfileRepository.Update(userAdditionalDetail);
            _unitOfWork.Save();
            result = true;
            return result;
        }
        /// <summary>
        /// for get all fruits
        /// </summary>
        public IEnumerable<ViewModel.TravelPreferences> GetAllTravelPreference(int loginId)
        {
           var travelPreferences = _unitOfWork.TravelPreferencesRepository.GetAll();
            var userTravelPrefMapping = _unitOfWork.UserTravelPrefMapRepository.GetMany(x => x.LoginId == loginId);

            var travelPref = new List<ViewModel.TravelPreferences>();

            foreach (var item in travelPreferences)
            {
                travelPref.Add(new ViewModel.TravelPreferences { id = item.Id, Name = item.Name, IsChecked = userTravelPrefMapping.Any(x=>x.TravelPrefId == item.Id )});
            }
            return travelPref;
        }
        public SelectList GetPreferedContactMethod()
        {
            var lstPrefContact = new List<ddlPreferContact>();
            lstPrefContact.Add(new ddlPreferContact { Value = 1, Text = "Email" });
            lstPrefContact.Add(new ddlPreferContact { Value = 2, Text = "Mobile" });
            lstPrefContact.Add(new ddlPreferContact { Value = 3, Text = "Telephone" });
            SelectList selesctedPrefContact = new SelectList(lstPrefContact, "Value", "Text");
            return selesctedPrefContact;
        }
        public SelectList GetCallTime()
        {
            var lstCallTime = new List<ddlCallTime>();
            lstCallTime.Add(new ddlCallTime { Value = 1, Text = "AM" });
            lstCallTime.Add(new ddlCallTime { Value = 1, Text = "PM" });
            SelectList selesctedCallTime = new SelectList(lstCallTime, "Value", "Text");
            return selesctedCallTime;
        }
    }
}

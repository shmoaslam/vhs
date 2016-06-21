using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VHS.Interface;
using VHS.Repository;
using VHS.Services.Interface;
using VHS.Services.Models;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public class PropertyBookingService : IPropertyBooking
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        public PropertyBookingService(INotificationService notificationService)
        {
            _unitOfWork = new UnitOfWork();
            _notificationService = notificationService;
        }
        public bool CheckPropertyAvailbility(PropertyBooking propertyBook)
        {
            var availability = _unitOfWork.CheckAvailbilityProerty(propertyBook.PropertyId, (DateTime)propertyBook.StartDate, (DateTime)propertyBook.EndDate);
            return availability;
        }
        public bool BookProperty(PropertyBooking propertyBook)
        {
            bool result = false;
            int loginId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

            if (!CheckPropertyAvailbility(propertyBook))
            {
                _unitOfWork.PropertyBookingRepository.Insert(new Core.PropertyBooking { LoginId = loginId, StartDate = propertyBook.StartDate,
                    EndDate = propertyBook.EndDate, PropertyId = propertyBook.PropertyId, GuestCount = propertyBook.GuestNo, ChildCount = propertyBook.ChildNo
                , AdultCount = propertyBook.AdultNo, AproxPrice = propertyBook.AprroxPrice});
                _unitOfWork.Save();
                result = true;

                //Property Book Confirmation to rm ,Admin and User confirmation:-
                var adminEmail = _unitOfWork.LoginRepository.GetAll();
                if (adminEmail.Count() > 0)
                {
                    var propertyRMId = _unitOfWork.PropertyRMMapRepository.GetSingle(m => m.PropertyId == propertyBook.PropertyId).LoginId;
                    var bookingConfirmation = new BookingConfirmation();


                    bookingConfirmation.AdminEmail = "velvetthomestays@vikasgroup.com";//adminEmail.Where(m => m.TypeId == 1).FirstOrDefault().Email.ToString();

                    var rm = adminEmail.Where(m => m.LoginId == propertyRMId).FirstOrDefault();
                    bookingConfirmation.RmEmail = rm.Email;
                    bookingConfirmation.RmName = rm.Name;

                    var userDetail = adminEmail.Where(m => m.LoginId == loginId).FirstOrDefault();
                    bookingConfirmation.Email = userDetail.Email;
                    bookingConfirmation.UserName = userDetail.Name;
                    bookingConfirmation.Mobile = _unitOfWork.UserProfileRepository.GetFirst(x => x.LoginId == loginId).Mobile; ;

                    bookingConfirmation.GuestCount = propertyBook.GuestNo;
                    bookingConfirmation.StartDate = Convert.ToDateTime( propertyBook.StartDate).ToShortDateString();
                    bookingConfirmation.EndDate = Convert.ToDateTime(propertyBook.EndDate).ToShortDateString();
                    bookingConfirmation.Property = "VH" + propertyBook.PropertyId.ToString("D5");
                    bookingConfirmation.PropertyName = propertyBook.PropertyName;

                    _notificationService.BookingConfirmationMail(bookingConfirmation);
                }

                return result;
            }
            else
            {
                return result;
            }
        }

        public decimal? GetTotalPrice(PropertyBooking propertyBook)
        {
            var totalPrice = _unitOfWork.GetBookingPrice(propertyBook.PropertyId, (DateTime)propertyBook.StartDate, (DateTime)propertyBook.EndDate, propertyBook.AdultNo, propertyBook.ChildNo);
            return  totalPrice ;
        }

   
    }
}

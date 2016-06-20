using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Repository;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public class ManageBookingService : IManageBookingService
    {
        private readonly UnitOfWork _unitOfWork;

        public ManageBookingService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ManganeBookingViewModel GetBookingDetails(int id)
        {
            var booking = _unitOfWork.GetBookingDetails(id);

            return new ManganeBookingViewModel
            {
                Id = booking.Id,
                AdultCount = booking.AdultCount,
                CheckIn = booking.CheckIn,
                Email = booking.Email,
                Name = booking.Name,
                PropertyId = booking.PropertyId,
                BookingId = booking.BookingId,
                CheckOut = booking.CheckOut,
                ChildCount = booking.ChildCount,
                ContactNumber = booking.ContactNumber,
                QuotedPrice = booking.QuotedPrice,
                Guests = booking.Guests,
                LoginId = booking.LoginId
            };
        }

        public List<ManganeBookingViewModel> GetBookings(int rmId)
        {
            var bookings = _unitOfWork.GetBookings(rmId);
            var bookingsViewModel = new List<ManganeBookingViewModel>();
            foreach (var booking in bookings)
            {
                bookingsViewModel.Add(new ManganeBookingViewModel { BookingId = booking.BookingId, Id = booking.Id, PropertyDisplayName = booking.PropertyDisplayName, PropertyId = booking.PropertyId });
            }

            return bookingsViewModel;
        }

        public bool UpdateBooking(ManganeBookingViewModel model)
        {
            var booking = _unitOfWork.PropertyBookingRepository.GetByID(model.Id);

            booking.NegoPric = model.NegotiatePrice;
            booking.GuestCount = model.Guests;
            booking.UserComments = model.UserComment;
            booking.RmComment = model.RmComment;
            booking.RemainPrice = model.RecievedPayment;
            booking.StartDate = model.CheckIn;
            booking.EndDate = model.CheckOut;
            booking.AdultCount = model.AdultCount;
            booking.ChildCount = model.ChildCount;
            booking.AproxPrice = model.QuotedPrice;
            booking.IsCustomerIdCollected = model.IsCustomerIdAvailable;


            _unitOfWork.PropertyBookingRepository.Update(booking);
            try
            {
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

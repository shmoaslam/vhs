using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Core;
using VHS.Interface;
using VHS.Repository;
using VHS.Services.Interface;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public class HomeService : IHomeService
    {

        private readonly UnitOfWork _unitOfWork;
        private INotificationService _notificationService;

        public HomeService(UnitOfWork unitOfWork, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        public bool AddBookingRequest(BookingRequestViewModel viewModel)
        {
            if (viewModel == null) return false;
            var model = GetBookingRequestModel(viewModel);
            if (model == null) return false;
            _unitOfWork.BookingRequestRepository.Insert(model);
            try
            {
                _unitOfWork.Save();
                _notificationService.SendBookingRequestMail(viewModel);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddNewsletter(NewsletterViewModel viewModel)
        {
            if (viewModel == null) return false;
            var model = GetNewsletterModel(viewModel);
            if (model == null) return false;
            _unitOfWork.NewsletterRepository.Insert(model);
            try
            {
                _unitOfWork.Save();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Newsletter GetNewsletterModel(NewsletterViewModel viewModel)
        {
            if (viewModel == null) return null;
            return new Newsletter
            {
                Name = viewModel.Name,
                Email = viewModel.Email
            };
        }

        private BookingRequest GetBookingRequestModel(BookingRequestViewModel viewModel)
        {
            if (viewModel == null) return null;
            return new BookingRequest
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                Email = viewModel.Email
            };
        }
    }
}

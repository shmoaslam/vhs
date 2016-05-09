using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VHS.Repository;
using VHS.Services.Interface;
using VHS.Services.Models;

namespace VHS.Services
{
    public class PropertyBookingService : IPropertyBooking
    {
        private readonly UnitOfWork _unitOfWork;
        public PropertyBookingService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public bool CheckPropertyAvailbility(PropertyBooking propertyBook)
        {
            var availability = _unitOfWork.CheckAvailbilityProerty(propertyBook.PropertyId, (DateTime)propertyBook.StartDate, (DateTime)propertyBook.EndDate);
            return true;
        }
        public bool BookProperty(PropertyBooking propertyBook)
        {
            bool result = false;
            if (CheckPropertyAvailbility(propertyBook))
            {
                _unitOfWork.PropertyBookingRepository.Insert(new Core.PropertyBooking { LoginId = 14, StartDate = propertyBook.StartDate, EndDate = propertyBook.EndDate, PropertyId = propertyBook.PropertyId });
                _unitOfWork.Save();
                result = true;
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}

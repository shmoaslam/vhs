using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public interface IManageBookingService
    {
        ManganeBookingViewModel GetBookingDetails(int id);
        bool UpdateBooking(ManganeBookingViewModel model);
        BookingDisplayViewModel GetPropertyForManage(int rmId);
    }
}

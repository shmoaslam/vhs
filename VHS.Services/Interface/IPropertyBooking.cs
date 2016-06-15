using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.Models;

namespace VHS.Services.Interface
{
    public interface IPropertyBooking
    {
        bool CheckPropertyAvailbility(PropertyBooking propertyBooking);
        bool BookProperty(PropertyBooking propertyBooking);
        decimal GetTotalPrice(PropertyBooking propertyBooking);
    }
}

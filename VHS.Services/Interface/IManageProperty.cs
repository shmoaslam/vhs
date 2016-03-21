using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.ViewModel;

namespace VHS.Interface
{
    public interface IManageProperty
    {
        PropertyRMViewModel GetAssignedProperty();
        bool SetPropertyToRm(PropertyRMViewModel proprmView);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VHS.Services.Models;
using VHS.Services.ViewModel;

namespace VHS.Interface
{
    public interface IProperty
    {
        bool AddProperty(Property property, List<HttpPostedFileBase> file);
        List<PropertyViewModel> GetPropertyList();
        PropertyDisplayViewModel GetPropertyDisplayModel(int? id);
        IList<PropertyDisplayViewModel> GetAllProperty();
        IList<PropertyDisplayViewModel> GetAllSpainProperty();
        IList<PropertyDisplayViewModel> GetIndianProperty();
    }
}

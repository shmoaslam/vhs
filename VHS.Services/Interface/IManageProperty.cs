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
    public interface IManageProperty
    {
        PropertyRMViewModel GetAssignedProperty();
        bool SetPropertyToRm(PropertyRMViewModel proprmView);
        List<PropertyRMMap> GetPropRmMap();

        List<PropertyViewModel> GetPropertyForManage(int rmID);

        PropertyEditViewModel GetPropertyDetail(int PropertyId);
        bool UpdateGeneralInfo(PropertyGeneralInfo propGeneralInfo, List<HttpPostedFileBase> Image);
        bool UpdateAdditionalInfo(PropertyAdditionalInfoModel propAdditionalInfoInfo);
        bool UpdateAppearanceSetting(PropertyPhoto propPhoto, List<HttpPostedFileBase> ImageCoverPhoto, List<HttpPostedFileBase> ImageGallaryPhoto);
        bool UpdateTravelAmbassador(PropertyTravelAmbassador propTravelAmbass);
        bool UpdateTransferProperty(PropertyTransfer propTransfer);
        bool DeleteProperty(int PropertyId);
    }
}

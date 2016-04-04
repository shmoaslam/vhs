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
        bool UpdateAmenities(PropertyAmenities propAmenities);
        bool UpdateTravelAmbassador(PropertyTravelAmbassador propTravelAmbass);
        bool UpdateTransferProperty(PropertyTransfer propTransfer);
        bool DeleteProperty(PropertyDelete propertyDelete);
        bool UpdatePropGallaryPhoto(PropertyGallaryPhoto propertyCoverPhoto, List<HttpPostedFileBase> GallaryPhoto);
        bool UpdatePropCoverPhoto(PropertyCoverPhoto propertyCoverPhoto, List<HttpPostedFileBase> CoverPhoto);
        bool UpdatePropVariablePrice(PropertyVarablePricing propVarablePrice);
        bool UpdatePropFixPrice(PropertyFixedPricing propFixedPrice);

        //Get Gallary Photo:-
        PropertyGallaryPhoto GetPropertyGallaryPhoto(int propertyId);
        PropertyCoverPhoto GetPropertyCoverPhoto(int propertyId);
        
    }
}

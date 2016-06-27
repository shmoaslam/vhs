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
        //Get Gallary Photo:-
        //PropertyEditViewModel GetPropertyDetail(int PropertyId);
        PropertyGeneralInfo GetPropertyGeneralInfo(int PropertyId);
        PropertyAdditionalInfoModel GetPropertyAdditionalInfo(int PropertyId);
        PropertyAmenities GetPropertyAmenities(int PropertyId);
        PropertyFixedPricing GetPropertyFixedPrice(int PropertyId);
        AdminHomeViewModel GetApprovedWaitingProperty();
        PropertyVarablePricing GetPropertyVaraiablePrice(int PropertyId);
        PropertyWeekendPricing GetPropertyWeekendPrice(int PropertyId);
        AdminHomeViewModel GetDeleteRequestProperty();
        PropertyTransfer GetPropertyTransfer(int PropertyId);
        PropertyNotification GetPropertyDelete(int PropertyId);
        PropertyNotification GetPropertyApproval(int id);
        PropertyGallaryPhoto GetPropertyGallaryPhoto(int propertyId);
        PropertyCoverPhoto GetPropertyCoverPhoto(int propertyId);


        bool UpdateGeneralInfo(PropertyGeneralInfo propGeneralInfo, List<HttpPostedFileBase> Image);
        bool UpdateAdditionalInfo(PropertyAdditionalInfoModel propAdditionalInfoInfo);
        bool UpdateAmenities(PropertyAmenities propAmenities);
        bool UpdateTravelAmbassador(PropertyTravelAmbassador propTravelAmbass);
        bool UpdateTransferProperty(PropertyTransfer propTransfer);
        bool DeleteProperty(PropertyNotification propertyDelete);
        bool UpdatePropGallaryPhoto(PropertyGallaryPhoto propertyCoverPhoto, List<HttpPostedFileBase> GallaryPhoto);
        bool UpdatePropCoverPhoto(PropertyCoverPhoto propertyCoverPhoto, List<HttpPostedFileBase> CoverPhoto);
        bool UpdatePropVariablePrice(PropertyVarablePricing propVarablePrice);
        bool UpdatePropFixPrice(PropertyFixedPricing propFixedPrice);
        bool UpdatePropWeekEndPrice(PropertyWeekendPricing propWePrice);
        bool PropertyAprrovalRequest(PropertyNotification notification);
        bool PropertyDeleteRequest(PropertyNotification notification);
        bool ApprovedProperty(PropertyNotification notification);
        RelatedProperty GetRelatedProperty(int id);
        bool UpdateRelatedProperty(RelatedProperty model);
        List<string> GetRelatedPropertyAutocompleteHelp(string query, int regionId);
    }
}

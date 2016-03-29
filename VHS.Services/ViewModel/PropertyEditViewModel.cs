using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.Models;

namespace VHS.Services.ViewModel
{
    public class PropertyEditViewModel
    {
        public PropertyGeneralInfo propertyGeneralInfo { get; set; }
        public PropertyAdditionalInfoModel propertyAdditionalInfo { get; set; }
        public PropertyAmenities propertyAmenities { get; set; }
        public PropertyFixedPricing propertyFixPricing { get; set; }
        public PropertyVarablePricing propertVarablePricing { get; set; }
        public PropertyCoverPhoto propertyCoverPhoto { get; set; }
        public PropertyGallaryPhoto propertyGallaryPhoto { get; set; }
        public PropertyTravelAmbassador propertyTravelAmbassdor { get; set; }
        public PropertyTransfer propertyTransfer { get; set; }
        public PropertyDelete propertyDelete { get; set; }
    }
}

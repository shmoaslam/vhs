using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VHS.Repository;
using VHS.Services.Interface;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public IList<PropertyListingViewModel> GetAllPropertiesByCategory(int? id)
        {
            if (id == null) return null;

            var properties = _unitOfWork.PropertyRepository.GetMany(x => x.CategoryId == id && x.IsApproved && x.IsActive);

            if (properties == null) return null;

            IList<PropertyListingViewModel> model = new List<PropertyListingViewModel>();

            foreach (var property in properties)
            {
                string image = string.Empty;
                string location = string.Empty;
                if(_unitOfWork.PropertyImageMapRepository.GetManyQueryable(x=>x.PropertyId == property.Id).Any())
                {
                    var imageId = _unitOfWork.PropertyImageMapRepository.GetFirst(y => y.PropertyId == property.Id).ImageId;
                   var imageObj = _unitOfWork.ImageRepository.GetManyQueryable(x => x.ImageId == imageId);
                    if(imageObj != null)
                    {
                        image = imageObj.FirstOrDefault().Name;
                    }
                    var addressObj = _unitOfWork.PropertyAddressRepository.GetManyQueryable(x => x.PropertyId == property.Id);
                    if (addressObj != null)
                    {
                        location = addressObj.FirstOrDefault().City;
                    }
                }
                model.Add(new PropertyListingViewModel { Name= property.Title 
                                                        , ImageLoc = string.IsNullOrEmpty(image) ? string.Empty :  image
                                                        , Location = string.IsNullOrEmpty(location) ? string.Empty : location
                                                        , Id = property.Id });
                
            }
            return model;
        }
    }
}

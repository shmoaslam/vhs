﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.ViewModel;

namespace VHS.Services.Interface
{
    public interface ICategoryService
    {
        IList<PropertyListingViewModel> GetAllPropertiesByCategory(int? id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Interface;
using VHS.Repository;
using VHS.Services.Models;

namespace VHS.Services
{
    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;
        public UserService()
        {
            _unitOfWork = new UnitOfWork();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Interface
{
    public interface INotificationService
    {
        void UserRegistration(string Email, string Name);
        void RmAccountCreation(string Email, string Name, int RMId);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Core;

namespace VHS.Data
{
    public class VHSDbInitializer : DropCreateDatabaseAlways<VHSDbContext>
    {
        protected override void Seed(VHSDbContext context)
        {
            IList<UserType> userType = new List<UserType>();

            userType.Add(new UserType() { Name = "Admin", Description = "Admin rights", UpdatedBy = 0, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, CreatedBy = 0, IsActive = true });
            userType.Add(new UserType() { Name = "User", Description = "Normal User", UpdatedBy = 0, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, CreatedBy = 0, IsActive = true });
            userType.Add(new UserType() { Name = "RM", Description = "RM", UpdatedBy = 0, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, CreatedBy = 0, IsActive = true });
            userType.Add(new UserType() { Name = "TravelAmbessdor", Description = "Travel Ambesdor", UpdatedBy = 0, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, CreatedBy = 0, IsActive = true });

            foreach (UserType type in userType)
                context.UserTypes.Add(type);

            base.Seed(context);
        }
    }
}

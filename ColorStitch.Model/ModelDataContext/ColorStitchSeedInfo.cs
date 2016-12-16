using SmartHome.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Entities.EntiyDataContext;
using System.Data.Entity.Migrations;

namespace ColorStitch.Model.ModelDataContext
{
    public class ColorStitchSeedInfo
    {
        public void ProjectSeed(ColorStitchDataContext context)
        {
            context.Users.AddOrUpdate(p => p.UserFullName,
                    new User() { UserFullName = "Admin", UserLoginId = "Admin", UserPassword = "123", InsertUserID = 1, InsertDate = DateTime.Now, IsAdmin = true, ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added }
                    );
            context.SaveChanges();

            context.DateFormatAndRulesConfigurations.AddOrUpdate(p => p.MinDate,
                   new DateFormatAndRulesConfiguration() { MinDate = -1, MaxDate = "+0M +1D", DateFormat = "dd/M/yy", IsActive = true, InsertUserID = 1, InsertDate = DateTime.Now, ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added }
                   );
            context.SaveChanges();
        }
    }
}

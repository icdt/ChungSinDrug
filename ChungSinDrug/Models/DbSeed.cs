using System;
using System.Linq;

namespace icdtFramework.Models
{
    public class DbSeed
    {
        public void SeedManagerAccout()
        {
            ApplicationUserModel user1 = new ApplicationUserModel();
            user1.Id = Guid.NewGuid().ToString();
            user1.UserName = "icdt";
            user1.Password = "P@ssw0rd";

            var userId = UserAccountManager.Create(user1);
            if (!String.IsNullOrWhiteSpace(userId))
            {
                AuthOption aa = new AuthOption();
                aa.AuthOption_Admin = true;

                using (ApplicationDbContext db=new ApplicationDbContext())
                {
                    var theUser = db.Users.FirstOrDefault(a => a.Id == userId);
                    UserAccountManager.InsertOrUpdateAuthOption(theUser, aa);
                }
            }

            EmployeeUserModel emp1 = new EmployeeUserModel();
            emp1.Id = Guid.NewGuid().ToString();
            emp1.UserName = "manager";
            emp1.Password = "abc123";
            emp1.EmployeeProfile_Name = "M";

            var empId = UserAccountManager.CreateEmployee(emp1);
            if (!String.IsNullOrWhiteSpace(empId))
            {
                AuthOption aa = new AuthOption();
                aa.AuthOption_Admin = true;

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var theUser = db.Users.FirstOrDefault(a => a.Id == empId);
                    UserAccountManager.InsertOrUpdateAuthOption(theUser, aa);
                }
            }
        }
    }
}

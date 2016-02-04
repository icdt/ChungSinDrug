using ChungSinDrug;
using ChungSinDrug.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace icdtFramework.Models
{
    public class CustomerProfile:MemberProfile
    {
      
        public string CustomerProfile_Name { get; set; }
    }

    public class CustomerUserModel : ApplicationUserModel
    {
        public string CustomerProfile_Name { get; set; }
    }

    public static partial class UserAccountManager
    {
        public static string CreateCustomer(EmployeeUserModel userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

                ApplicationUser newUser = new ApplicationUser()
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                    UserProfile = new EmployeeProfile()
                    {
                        EmployeeProfile_Name = userModel.EmployeeProfile_Name
                    }
                };

                var userPassword = String.IsNullOrEmpty(userModel.Password) ? "abc123" : userModel.Password;
                var result = userManager.Create(newUser, userPassword);
                if (result.Succeeded)
                {
                    return newUser.Id;
                }
                else
                {
                    return "";
                }

            }
        }

        public static void UpdateCustomer(EmployeeUserModel userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(a => a.Id == userModel.Id);

                user.UserName = userModel.UserName;
                user.Email = userModel.Email;
                ((EmployeeProfile)user.UserProfile).EmployeeProfile_Name = userModel.EmployeeProfile_Name;

                db.SaveChanges();
            }
        }
    }
}

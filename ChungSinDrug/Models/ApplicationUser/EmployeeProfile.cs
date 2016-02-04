using ChungSinDrug;
using ChungSinDrug.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace icdtFramework.Models
{
    public class EmployeeProfile : MemberProfile
    {
       
        public string EmployeeProfile_Name { get; set; }

    }

    public class EmployeeUserModel : ApplicationUserModel
    {
        public string EmployeeProfile_Name { get; set; }
    }

    public static partial class UserAccountManager
    {
        public static string CreateEmployee(EmployeeUserModel userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUserManager userManager = GetUserManager();

                ApplicationUser newUser = new ApplicationUser()
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                    CreateTime = DateTime.Now,
                    CreatorUserName = userModel.CreatorUserName,
                    CreatorId = userModel.CreatorId,
                    UpdateTime = DateTime.Now,
                    UpdaterUserName = userModel.UpdaterUserName,
                    UpdaterId = userModel.UpdaterId,
                    UserProfile = new EmployeeProfile()
                    {
                        Profile_Id = Guid.NewGuid().ToString(),
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

        public static void UpdateEmployee(EmployeeUserModel userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(a => a.Id == userModel.Id);

                user.UserName = userModel.UserName;
                user.Email = userModel.Email;
                ((EmployeeProfile)user.UserProfile).EmployeeProfile_Name = userModel.EmployeeProfile_Name;

                user.UpdateTime = DateTime.Now;
                user.UpdaterUserName = userModel.UpdaterUserName;
                user.UpdaterId = userModel.UpdaterId;

                db.SaveChanges();
            }
        }
    }
}

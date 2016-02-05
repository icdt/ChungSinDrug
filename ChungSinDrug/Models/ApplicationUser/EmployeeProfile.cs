using ChungSinDrug;
using ChungSinDrug.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace icdtFramework.Models
{
    public class EmployeeProfile : MemberProfile
    {
        public string EmployeeProfile_Name { get; set; }

        public EmployeeProfile()
        {
            this.Profile_Id = Guid.NewGuid().ToString();
            this.EmployeeProfile_Name = "";
        }
    }

    public class EmployeeUserModel : ApplicationUserModel
    {
        public string EmployeeProfile_Name { get; set; }
    }

    public static partial class UserAccountManager
    {
        public static List<EmployeeUserModel> GetAllEmployees()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<EmployeeUserModel> returnList = new List<EmployeeUserModel>();

                var empolyeeProfiles = db.MemberProfiles.OfType<EmployeeProfile>().AsQueryable();
                var userAccounts = db.Users.ToList();
                foreach (EmployeeProfile item in empolyeeProfiles)
                {
                    var theUserAccount = userAccounts.FirstOrDefault(a => a.IdFK_UserProfile == item.Profile_Id);

                    EmployeeUserModel aa = new EmployeeUserModel();

                    // 帳號資訊
                    aa.Id = theUserAccount.Id;
                    aa.UserName = theUserAccount.UserName;
                    aa.Email = theUserAccount.Email;
                    aa.DelLock = theUserAccount.DelLock;

                    // 基本資料資訊
                    aa.EmployeeProfile_Name = item.EmployeeProfile_Name;

                    // 其他資訊
                    aa.CreateTime = theUserAccount.CreateTime;
                    aa.CreatorId = theUserAccount.CreatorId;
                    aa.CreatorUserName = theUserAccount.CreatorUserName;
                    aa.UpdateTime = theUserAccount.UpdateTime;
                    aa.UpdaterId = theUserAccount.UpdaterId;
                    aa.UpdaterUserName = theUserAccount.UpdaterUserName;

                    returnList.Add(aa);
                }

                return returnList;
            }
        }

        public static EmployeeUserModel GetEmployeeById(string id)
        {
            var employeeUserModels = GetAllEmployees();
            return employeeUserModels.FirstOrDefault(a => a.Id == id);
        }

        public static EmployeeUserModel GetEmployeeByUserName(string userName)
        {
            var employeeUserModels = GetAllEmployees();
            return employeeUserModels.FirstOrDefault(a => a.UserName == userName);
        }

        public static string CreateEmployee(EmployeeUserModel userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUserManager userManager = GetUserManager();

                var creatorUserAccount = db.Users.FirstOrDefault(a => a.UserName == userModel.CreatorUserName);
                var updaterUserAccount = db.Users.FirstOrDefault(a => a.UserName == userModel.UpdaterUserName);

                ApplicationUser newUser = new ApplicationUser()
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                    IdFK_AuthOptions = "",
                    CreateTime = DateTime.Now,
                    CreatorUserName = userModel.CreatorUserName,
                    CreatorId = creatorUserAccount == null ? "" : creatorUserAccount.Id,
                    UpdateTime = DateTime.Now,
                    UpdaterUserName = userModel.UpdaterUserName,
                    UpdaterId = updaterUserAccount == null ? "" : updaterUserAccount.Id,
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
                var updaterUserAccount = db.Users.FirstOrDefault(a => a.UserName == userModel.UpdaterUserName);

                user.UserName = userModel.UserName;
                user.Email = userModel.Email;
                ((EmployeeProfile)user.UserProfile).EmployeeProfile_Name = userModel.EmployeeProfile_Name;

                user.UpdateTime = DateTime.Now;
                user.UpdaterUserName = userModel.UpdaterUserName;
                user.UpdaterId = updaterUserAccount == null ? "" : updaterUserAccount.Id;

                db.SaveChanges();
            }
        }
    }
}

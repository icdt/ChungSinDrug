using ChungSinDrug.Models;
using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ChungSinDrug;
using icdtFramework.Identity;

namespace icdtFramework.Models
{
    public static partial class UserAccountManager
    {
        public static ApplicationUser GetByName(string userName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Users.FirstOrDefault(a => a.UserName == userName);
            }
        }

        #region 純粹建立帳號
        public static string Create(ApplicationUserModel userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                userManager.PasswordHasher = new AESPasswordHasher();

                ApplicationUser newUser = new ApplicationUser()
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                    CreateTime = DateTime.Now,
                    CreatorUserName = userModel.CreatorUserName,
                    CreatorId = userModel.CreatorId,
                    UpdateTime = DateTime.Now,
                    UpdaterUserName = userModel.UpdaterUserName,
                    UpdaterId = userModel.UpdaterId
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

        public static void UpdateEmployee(ApplicationUserModel userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(a => a.Id == userModel.Id);

                user.UserName = userModel.UserName;
                user.Email = userModel.Email;
                user.UpdateTime = DateTime.Now;
                user.UpdaterUserName = userModel.UpdaterUserName;
                user.UpdaterId = userModel.UpdaterId;

                db.SaveChanges();
            }
        }
        #endregion

        public static void UpdatePassword(ApplicationUserModel userModel)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            userManager.RemovePassword(userModel.Id);
            userManager.AddPassword(userModel.Id, userModel.Password);

            return;
        }

        public static void InsertOrUpdateAuthOption(ApplicationUser user, AuthOption authOption)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var userInDB = db.Users.FirstOrDefault(a => a.Id == user.Id);
                var authOptionInDB = db.AuthOptions.FirstOrDefault(a => a.AuthOption_Id == userInDB.IdFK_AuthOptions);

                // create
                if (authOptionInDB == null)
                {
                    userInDB.AuthOptions = authOption;
                    db.SaveChanges();
                    return;
                }

                authOptionInDB.AuthOption_Admin = authOption.AuthOption_Admin;
                //authOptionInDB.Taipei = authOption.Taipei;
                //authOptionInDB.Taoyuan = authOption.Taoyuan;
                //authOptionInDB.OrderTrucks = authOption.OrderTrucks;
                //authOptionInDB.OrderAirDoc = authOption.OrderAirDoc;
                //authOptionInDB.OrderInCityDoc = authOption.OrderInCityDoc;
                //authOptionInDB.Bills = authOption.Bills;
                //authOptionInDB.Drivers = authOption.Drivers;
                //authOptionInDB.Sales = authOption.Sales;
                //authOptionInDB.Customers = authOption.Customers;
                //authOptionInDB.PriceTemplate = authOption.PriceTemplate;
                //authOptionInDB.Employee = authOption.Employee;

                db.SaveChanges();
            }
        }

        public static void Remove(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(a => a.Id == id);
                user.UserName = user.UserName + "_deleted";
                user.DelLock = true;

                db.SaveChanges();
            }
            return;
        }



    }
}

using ChungSinDrug;
using ChungSinDrug.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace icdtFramework.Models
{
    public class CustomerProfile : MemberProfile
    {
        public string CustomerProfile_Name { get; set; }

        public CustomerProfile()
        {
            this.Profile_Id = Guid.NewGuid().ToString();
            this.CustomerProfile_Name = "";
        }
    }

    public class CustomerUserModel : ApplicationUserModel
    {
        public string CustomerProfile_Name { get; set; }

        public CustomerUserModel():base()
        {
        }

        public CustomerUserModel(string userName,
            string password,
            string email,
            string creatorUserName,
            string updaterUserName,
            string customerProfile_Name)
            : base(userName, password, email, creatorUserName, updaterUserName)
        {
            this.CustomerProfile_Name = customerProfile_Name;
        }

    }

    public static partial class UserAccountManager
    {
        public static List<CustomerUserModel> GetAllCustomers()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<CustomerUserModel> returnList = new List<CustomerUserModel>();

                var empolyeeProfiles = db.MemberProfiles.OfType<CustomerProfile>().AsQueryable();
                var userAccounts = db.Users.ToList();
                foreach (CustomerProfile item in empolyeeProfiles)
                {
                    var theUserAccount = userAccounts.FirstOrDefault(a => a.IdFK_UserProfile == item.Profile_Id);

                    CustomerUserModel aa = new CustomerUserModel();

                    // 帳號資訊
                    aa.Id = theUserAccount.Id;
                    aa.UserName = theUserAccount.UserName;
                    aa.Email = theUserAccount.Email;
                    aa.DelLock = theUserAccount.DelLock;

                    // 基本資料資訊
                    aa.CustomerProfile_Name = item.CustomerProfile_Name;

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

        public static CustomerUserModel GetCustomerById(string id)
        {
            var customerUserModels = GetAllCustomers();
            return customerUserModels.FirstOrDefault(a => a.Id == id);
        }

        public static CustomerUserModel GetCustomerByUserName(string userName)
        {
            var customerUserModels = GetAllCustomers();
            return customerUserModels.FirstOrDefault(a => a.UserName == userName);
        }

        public static string CreateCustomer(CustomerUserModel userModel)
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
                    CreateTime = DateTime.Now,
                    CreatorUserName = userModel.CreatorUserName,
                    CreatorId = creatorUserAccount == null ? "" : creatorUserAccount.Id,
                    UpdateTime = DateTime.Now,
                    UpdaterUserName = userModel.UpdaterUserName,
                    UpdaterId = updaterUserAccount == null ? "" : updaterUserAccount.Id,
                    UserProfile = new CustomerProfile()
                    {
                        Profile_Id = Guid.NewGuid().ToString(),
                        CustomerProfile_Name = userModel.CustomerProfile_Name
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

        public static void UpdateCustomer(CustomerUserModel userModel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(a => a.Id == userModel.Id);
                var updaterUserAccount = db.Users.FirstOrDefault(a => a.UserName == userModel.UpdaterUserName);

                user.UserName = userModel.UserName;
                user.Email = userModel.Email;
                ((CustomerProfile)user.UserProfile).CustomerProfile_Name = userModel.CustomerProfile_Name;

                user.UpdateTime = DateTime.Now;
                user.UpdaterUserName = userModel.UpdaterUserName;
                user.UpdaterId = updaterUserAccount == null ? "" : updaterUserAccount.Id;

                db.SaveChanges();
            }
        }
    }
}

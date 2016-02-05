using icdtFramework.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace icdtFramework.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("UserProfile")]
        public string IdFK_UserProfile { get; set; }
        public virtual MemberProfile UserProfile { get; set; }

        [ForeignKey("AuthOptions")]
        public string IdFK_AuthOptions { get; set; }
        public virtual AuthOption AuthOptions { get; set; }

        public bool DelLock { get; set; }

        public DateTime CreateTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorUserName { get; set; }

        public DateTime UpdateTime { get; set; }
        public string UpdaterId { get; set; }
        public string UpdaterUserName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在這裡新增自訂使用者宣告
            return userIdentity;
        }
    }
}
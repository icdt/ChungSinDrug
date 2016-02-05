using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icdtFramework.Models
{
    public class ApplicationUserModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public MemberProfile UserProfile { get; set; }

        public AuthOption AuthOptions { get; set; }

        public bool DelLock { get; set; }

        public DateTime CreateTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorUserName { get; set; }

        public DateTime UpdateTime { get; set; }
        public string UpdaterId { get; set; }
        public string UpdaterUserName { get; set; }

        public ApplicationUserModel()
        { }

        public ApplicationUserModel(
                string userName,
                string password,
                string email,
                string creatorUserName,
                string updaterUserName
            )
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.DelLock = false;
            this.CreateTime = DateTime.Now;
            this.CreatorId = "";
            this.CreatorUserName = creatorUserName;
            this.UpdateTime = DateTime.Now;
            this.UpdaterId = "";
            this.UpdaterUserName = updaterUserName;
        }


    }
}

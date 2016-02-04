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

        public bool DelLock { get; set; }

        public DateTime CreateTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorUserName { get; set; }

        public DateTime UpdateTime { get; set; }
        public string UpdaterId { get; set; }
        public string UpdaterUserName { get; set; }

    }
}

using icdtFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace icdtFramework.Controllers
{
    [Authorize]
    public class MvcBaseController : Controller
    {
        private ApplicationUserModel _loginUser = new ApplicationUserModel();

        public ApplicationUserModel loginUser
        {
            get
            {
                var user = UserAccountManager.GetByName(User.Identity.Name);
                return user;
                //return MemberManager.GetByName(User.Identity.Name);
            }
            private set
            {
                _loginUser = value;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace icdtFramework.Filters
{
    public class AuthOptionAuthorizeAttribute : AuthorizeAttribute
    {

        private string[] _authOptions { get; set; }

        public AuthOptionAuthorizeAttribute(string AuthOptions)
        {
            // parse your usertypes here.
            _authOptions = AuthOptions.Split(',');
        }



        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (AuthorizeCore(filterContext.HttpContext))
            {
                // ** IMPORTANT **
                // Since we're performing authorization at the action level, the authorization code runs
                // after the output caching module. In the worst case this could allow an authorized user
                // to cause the page to be cached, then an unauthorized user would later be served the
                // cached page. We work around this by telling proxies not to cache the sensitive page,
                // then we hook our custom authorization code into the caching mechanism so that we have
                // the final say on whether a page should be served from the cache.

                HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                cachePolicy.AddValidationCallback(new HttpCacheValidateHandler(this.CacheValidateHandler), null /* data */);
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        // This method must be thread-safe since it is called by the thread-safe OnCacheAuthorization() method.
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            //var userIdentity = httpContext.User;
            //var loginUser = MemberManager.GetByName(userIdentity.Identity.Name);

            //if (loginUser == null)
            //{
            //    return false;
            //}

            //bool isAuthorized = false;
            //foreach (var item in _authOptions)
            //{
            //    if ("Admin".Equals(item) && loginUser.AuthOptions.AuthOption_Admin)
            //    {
            //        isAuthorized = true;
            //    }

            //    if ("Report".Equals(item) && loginUser.AuthOptions.AuthOption_Report)
            //    {
            //        isAuthorized = true;
            //    }

            //    if ("ReportOneMonth".Equals(item) && loginUser.AuthOptions.AuthOption_ReportOneMonth)
            //    {
            //        isAuthorized = true;
            //    }
            //}

            //return isAuthorized;
            return true;
        }

        protected void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
        }

    }

}
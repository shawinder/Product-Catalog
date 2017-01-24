using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ProductCatalog.AttributeFilters
{
    public class AreaAuthorizeAttribute : AuthorizeAttribute, IAuthenticationFilter
    {
        private readonly string area;
        //private readonly Service.User.ISecurity _securityService = new Service.User.Security();

        //Authorization
        public AreaAuthorizeAttribute(string area)
        {
            this.area = area;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string loginUrl = "";

            if (area == "Admin")
            {
                loginUrl = "~/Admin/Account/Login";
            }
            else if (area == "VManager")
            {
                loginUrl = "~/VManager/Account/Login";
            }

            filterContext.Result = new RedirectResult(loginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Url.PathAndQuery);
        }
        
        //Authentication
        public void OnAuthentication(AuthenticationContext context)
        {
            //_securityService.VMAuthorize(context);
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            //Required but no implementation needed
        }
    }
}
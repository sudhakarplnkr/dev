using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OnBoardingWEB.Filters
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;
        public ApiAuthorizeAttribute(params string[] roles)
        {
            this.allowedRoles = roles;
        }
        //public virtual void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (filterContext.HttpContext.Request.IsAuthenticated && !string.IsNullOrWhiteSpace(filterContext.HttpContext.User.Identity.Name))
        //    {
        //        string currentUserId = string.Empty;
        //        currentUserId = filterContext.HttpContext.User.Identity.Name.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[1];
        //        if (true)
        //        {

        //        }
        //    }
        //    else
        //    {

        //    }
        //}

        //public override void OnAuthorization(HttpActionContext filterContext)
        //{
        //    if (filterContext.Request.Headers.Authorization != null && !string.IsNullOrWhiteSpace(filterContext.RequestContext.Principal.Identity.Name))
        //    {
        //        string currentUserId = string.Empty;
        //        currentUserId = filterContext.RequestContext.Principal.Identity.Name.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[1];
        //        if (true)
        //        {

        //        }
        //    }
        //    else
        //    {

        //    }
        //}

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            throw new HttpResponseException(challengeMessage);

        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                //boolean logic to determine if you are authorized.  
                //We check for a valid token in the request header or cookie.
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
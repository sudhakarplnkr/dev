using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnBoarding.WebAPI.Common
{//
    public class CommonHelper
    {
        public static string GetLoginId(HttpContext requestContext)
        {
            string currentUserId = string.Empty;
            if (requestContext.Request.IsAuthenticated && !string.IsNullOrWhiteSpace(requestContext.User.Identity.Name))
            {
                //currentUserId = requestContext.User.Identity.Name.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[1];
                currentUserId = requestContext.User.Identity.Name;
            }
            return currentUserId;
        }
    }
}
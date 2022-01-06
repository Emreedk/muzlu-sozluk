using ContentProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentProject.WebUI.Filters
{
    public class AdminAuth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.Writer != null && CurrentSession.Writer.isAdmin == false)
            {
                filterContext.Result = new RedirectResult("/AdminCategory/AccessDenied");
            }
        }
    }
}
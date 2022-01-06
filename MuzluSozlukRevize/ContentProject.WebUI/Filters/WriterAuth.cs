using ContentProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentProject.WebUI.Filters
{
    public class WriterAuth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.Writer == null)
            {
                filterContext.Result = new RedirectResult("/Login/WriterLogin");
            }
        }
    }
}
using Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Utils
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        SmartBagEntities context = new SmartBagEntities(); // my entity  
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                if (SessionED.Current!=null)
                {
                    if (SessionED.Current.LoginUsuario != null && SessionED.Current.Perfil == role)
                    {
                        authorize = true;
                    }
                }


                //var user = context.AppUser.Where(m => m.UserID == GetUser.CurrentUser/* getting user form current context */ && m.Role == role &&
                //m.IsActive == true); // checking active users with allowed roles.  
                //if (user.Count() > 0)
                //{
                //     /* return true if Entity has current user(active) with specific role */
                //}
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }  
}
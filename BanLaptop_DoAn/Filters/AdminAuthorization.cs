﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanLaptop_DoAn.Filters
{
    public class AdminAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!(filterContext.HttpContext.User.IsInRole("Admin") || filterContext.HttpContext.User.IsInRole("Manager")))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}
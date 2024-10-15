using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanLaptop_DoAn.Filters
{
    public class MyExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string s = "Message: " + filterContext.Exception.Message;
            StreamWriter stream = File.AppendText(filterContext.HttpContext.Request.PhysicalApplicationPath + "\\errorlog.txt");
            stream.WriteLine(s);
            stream.Close();

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("~/Home/Error");

        }
    }
}
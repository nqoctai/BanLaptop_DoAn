using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanLaptop_DoAn.Filters;

namespace BanLaptop_DoAn.Areas.Admin.Controllers
{
    [MyAuthenFilter]
    [AdminAuthorization]
    public class TrangChuController : Controller
    {
        // GET: Admin/TrangChu
        public ActionResult Index()
        {
            return View();
        }
    }
}
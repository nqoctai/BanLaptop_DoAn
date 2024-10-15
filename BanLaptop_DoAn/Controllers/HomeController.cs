using BanLaptop_DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanLaptop_DoAn.Models;

namespace BanLaptop_DoAn.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            LaptopShopDbContext db = new LaptopShopDbContext();
            List<SanPham> danhSachSanPham = db.SanPhams.ToList();
            return View(danhSachSanPham);
        }

        public ActionResult Error404()
        {
            return View();
        }
    }
}
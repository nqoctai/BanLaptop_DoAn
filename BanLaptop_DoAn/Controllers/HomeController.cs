using BanLaptop_DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanLaptop_DoAn.Models;
using BanLaptop_DoAn.Filters;

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
        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult SanPham()
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            List<SanPham> danhSachSanPham = db.SanPhams.ToList();
            return View(danhSachSanPham);
        }

        [MyAuthenFilter]
        public ActionResult GioHang()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }

        [MyAuthenFilter]
        public ActionResult ThanhToan()
        {
            return View();
        }

        public ActionResult DatHangThanhCong()
        {
            return View();
        }
    }
}
using BanLaptop_DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanLaptop_DoAn.Models;
using BanLaptop_DoAn.Filters;
using System.Data.SqlClient;

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
            ViewBag.DanhSachThuongHieu = db.ThuongHieus.ToList();
            ViewBag.DanhSachMucDich = db.MucDichSuDungs.ToList();
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

        [HttpPost]
        public ActionResult LocSanPham(FormCollection c)
        {
            
            LaptopShopDbContext db = new LaptopShopDbContext();
            ViewBag.DanhSachThuongHieu = db.ThuongHieus.ToList();
            ViewBag.DanhSachMucDich = db.MucDichSuDungs.ToList();


            var thuongHieu = c.GetValues("txtThuongHieu");

            var mucDich = c.GetValues("txtMucDich");

            var gia = c.GetValues("txtMucGia");

            var sapXep = c["txtSapXep"];

            var query = db.SanPhams.AsQueryable();
            if (thuongHieu != null)
            {
                var longThuongHieuId = thuongHieu.Select(x => long.Parse(x)).ToList();
                query = query.Where(x => longThuongHieuId.Contains(x.ThuongHieuId));
            }

            if (mucDich != null)
            {
                var longMucDichId = mucDich.Select(x => long.Parse(x)).ToList();
                query = query.Where(x => longMucDichId.Contains(x.MucDichSuDungId));
            }

            //if (gia != null)
            //{
            //   foreach(var mucGia in gia)
            //    {
            //        switch(mucGia)
            //        {
            //            case "duoi-10-trieu":
            //                query = query.Where(x => x.Gia < 10000000);
            //                break;
            //            case "10-15-trieu":
            //                query = query.Where(x => x.Gia >= 10000000 && x.Gia < 15000000);
            //                break;
            //            case "15-20-trieu":
            //                query = query.Where(x => x.Gia >= 15000000 && x.Gia < 20000000);
            //                break;
            //            case "tren-20-trieu":
            //                query = query.Where(x => x.Gia >= 20000000);
            //                break;
            //        }
            //    }
            //}

            if (gia != null)
            {
                query = query.Where(x =>
                    gia.Contains("duoi-10-trieu") && x.Gia < 10000000 ||
                    gia.Contains("10-15-trieu") && x.Gia >= 10000000 && x.Gia < 15000000 ||
                    gia.Contains("15-20-trieu") && x.Gia >= 15000000 && x.Gia < 20000000 ||
                    gia.Contains("tren-20-trieu") && x.Gia >= 20000000
                );
            }

            switch (sapXep)
            {
                case "gia-tang-dan":
                    query = query.OrderBy(x => x.Gia);
                    break;
                case "gia-giam-dan":
                    query = query.OrderByDescending(x => x.Gia);
                    break;
            }
            var danhSachSanPham = query.ToList();
            return View("SanPham",danhSachSanPham);
        }
        
    }
}
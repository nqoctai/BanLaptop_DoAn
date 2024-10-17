using BanLaptop_DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanLaptop_DoAn.Filters;
using System.IO;

namespace BanLaptop_DoAn.Areas.Admin.Controllers
{

    //[MyAuthenFilter]
    //[AdminAuthorization]
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult BangSanPham()
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            List<SanPham> danhSachSanPham = db.SanPhams.ToList();
            return View(danhSachSanPham);
        }

        public ActionResult ThemSanPham()
        {   
            LaptopShopDbContext db = new LaptopShopDbContext();
            ViewBag.DanhSachThuongHieu = db.ThuongHieus.ToList();
            ViewBag.DanhSachLoaiSP = db.LoaiSanPhams.ToList();
            ViewBag.DanhSachMucDich = db.MucDichSuDungs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham(FormCollection c, HttpPostedFileBase hinhanhFile)
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            SanPham sp = new SanPham();
            sp.Ten = c["txtTen"];
            sp.Gia = double.Parse(c["txtGia"]);
            sp.MoTaChiTiet = c["txtMoTaChiTiet"];
            sp.MoTaNgan = c["txtMoTaNgan"];
            sp.SoLuong = int.Parse(c["txtSoLuong"]);
            string idThuongHieu = c["txtThuongHieu"];
            ThuongHieu thuongHieu = db.ThuongHieus.Find(long.Parse(idThuongHieu));
            sp.ThuongHieu = thuongHieu;
            string idLoaiSP = c["txtLoaiSanPham"];
            LoaiSanPham loaiSP = db.LoaiSanPhams.Find(long.Parse(idLoaiSP));
            sp.LoaiSanPham = loaiSP;
            string idMucDich = c["txtMucDich"];
            MucDichSuDung mucDich = db.MucDichSuDungs.Find(long.Parse(idMucDich));
            sp.MucDichSuDung = mucDich;
            if (hinhanhFile != null && hinhanhFile.ContentLength > 0)
            {
                // Lấy tên file và đường dẫn lưu trữ
                var fileName = Path.GetFileName(hinhanhFile.FileName);
                var uploadDir = "~/Content/Upload/HinhAnh";
                var path = Path.Combine(Server.MapPath(uploadDir), fileName);

                // Lưu file lên server
                hinhanhFile.SaveAs(path);

                // Gán đường dẫn avatar vào đối tượng người dùng
                sp.HinhAnh = fileName;
            }
            db.SanPhams.Add(sp);
            db.SaveChanges();
            return RedirectToAction("BangSanPham");
        }


        public ActionResult XemSanPham(long? id)
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            SanPham sp = db.SanPhams.Find(id);
            return View(sp);
        }


        public ActionResult ChinhSuaSanPham(long? id)
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            SanPham sp = db.SanPhams.Find(id);
            ViewBag.DanhSachThuongHieu = db.ThuongHieus.ToList();
            ViewBag.DanhSachLoaiSP = db.LoaiSanPhams.ToList();
            ViewBag.DanhSachMucDich = db.MucDichSuDungs.ToList();
            return View(sp);
        }
        [HttpPost]
        public ActionResult ChinhSuaSanPham(long? id, FormCollection c, HttpPostedFileBase fileUpload)
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            SanPham sp = db.SanPhams.Find(id);
            sp.Ten = c["Ten"];
            sp.Gia = double.Parse(c["Gia"]);
            sp.MoTaChiTiet = c["MoTaChiTiet"];
            sp.MoTaNgan = c["MoTaNgan"];
            sp.SoLuong = int.Parse(c["SoLuong"]);
            string maTH = c["ThuongHieu"];
            ThuongHieu th = db.ThuongHieus.Find(long.Parse(maTH));
            sp.ThuongHieu = th;
            string idLoaiSP = c["LoaiSanPham"];
            LoaiSanPham loaiSP = db.LoaiSanPhams.Find(long.Parse(idLoaiSP));
            sp.LoaiSanPham = loaiSP;
            string idMucDich = c["MucDich"];
            MucDichSuDung mucDich = db.MucDichSuDungs.Find(long.Parse(idMucDich));
            sp.MucDichSuDung = mucDich;
            //sp.PhanKhucSanPham = c["PhanKhuc"];
            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                // Lấy tên file và đường dẫn lưu trữ
                var fileName = Path.GetFileName(fileUpload.FileName);
                var uploadDir = "~/Content/Upload/HinhAnh";
                var path = Path.Combine(Server.MapPath(uploadDir), fileName);

                // Lưu file lên server
                fileUpload.SaveAs(path);

                // Gán đường dẫn avatar vào đối tượng người dùng
                sp.HinhAnh = fileName;
            }
            db.SaveChanges();
            return RedirectToAction("BangSanPham");
        }


        [HttpGet]
        public ActionResult XoaSanPham(long? id)
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            SanPham sp = db.SanPhams.Find(id);
            return View(sp);
        }


        [HttpPost]
        public ActionResult XoaSanPham(FormCollection c)
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            SanPham sp = db.SanPhams.Find(long.Parse(c["ID"]));
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("BangSanPham");
        }


        [HttpPost]
        public ActionResult TimKiemSanPham(FormCollection c)
        {
            LaptopShopDbContext db = new LaptopShopDbContext();
            string searchText = c["txtSearch"];
            List<SanPham> danhSachSanPham = db.SanPhams.Where(sp => sp.Ten.Contains(searchText)).ToList();
            return View("BangSanPham", danhSachSanPham);
        }
        
    }
}
using BanLaptop_DoAn.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanLaptop_DoAn.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BanLaptop_DoAn.ViewModel;
using System.IO;

namespace BanLaptop_DoAn.Areas.Admin.Controllers
{
    [MyAuthenFilter]
    [AdminAuthorization]
    public class NguoiDungController : Controller
    {
        // GET: Admin/NguoiDung
        public ActionResult BangNguoiDung()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);
            

            List<NguoiDung> users = userManager.Users.ToList();
            var NguoiDungVaiTro = new List<NguoiDungVaiTroVM>();
            foreach (var user in users)
            {
                var userRoles = userManager.GetRoles(user.Id);
                NguoiDungVaiTroVM userVM = new NguoiDungVaiTroVM()
                {
                    Id = user.Id,
                    Email = user.Email,
                    TenNguoiDung = user.UserName,
                    DiaChi = user.DiaChi,
                    SoDienThoai = user.PhoneNumber,
                    VaiTro = userRoles[0]
                };
                NguoiDungVaiTro.Add(userVM);
            }
            return View(NguoiDungVaiTro);
        }

        public ActionResult ThemNguoiDung()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            ViewBag.Roles = roleManager.Roles.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ThemNguoiDung(FormCollection c, HttpPostedFileBase avatarFile)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);
            var user = new NguoiDung();
            user.UserName = c["txtTenDangNhap"];
            user.HoVaTen = c["txtHoVaTen"];
            user.Email = c["txtEmail"];
            user.DiaChi = c["txtDiaChi"];
            user.PhoneNumber = c["txtSDT"];
            string userPwd = c["txtMatKhau"];
            if (avatarFile != null && avatarFile.ContentLength > 0)
            {
                // Lấy tên file và đường dẫn lưu trữ
                var fileName = Path.GetFileName(avatarFile.FileName);
                var uploadDir = "~/Content/Upload/Avatar";
                var path = Path.Combine(Server.MapPath(uploadDir), fileName);

                // Lưu file lên server
                avatarFile.SaveAs(path);

                // Gán đường dẫn avatar vào đối tượng người dùng
                user.Avatar = fileName;
            }
            var chkUser = userManager.Create(user, userPwd);
            if(chkUser.Succeeded)
            {
                userManager.AddToRole(user.Id, c["txtRoleName"]);
            }
            return View();
        }

        
        public ActionResult ChinhSuaNguoiDung(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);
            NguoiDung user = userManager.FindById(id.ToString());
            ViewBag.Role = roleManager.Roles.ToList();

            if (user == null) {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult ChinhSuaNguoiDung(string id,FormCollection c, HttpPostedFileBase fileUpload)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);
            var user = userManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Cập nhật thông tin người dùng
            user.UserName = c["UserName"];
            user.HoVaTen = c["HoVaTen"];
            user.Email = c["Email"];
            user.DiaChi = c["DiaChi"];
            user.PhoneNumber = c["PhoneNumber"];
            user.PasswordHash = userManager.PasswordHasher.HashPassword(c["PasswordHash"]);
            var role = c["role"];
            if (role != null)
            {
                userManager.RemoveFromRole(user.Id, userManager.GetRoles(user.Id)[0]);
                userManager.AddToRole(user.Id, role);
            }

            // Xử lý file upload
            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                var uploadDir = "~/Content/Upload/Avatar";
                var path = Path.Combine(Server.MapPath(uploadDir), fileName);

                // Kiểm tra và tạo thư mục upload nếu không tồn tại
                if (!Directory.Exists(Server.MapPath(uploadDir)))
                {
                    Directory.CreateDirectory(Server.MapPath(uploadDir));
                }
                fileUpload.SaveAs(path);
                user.Avatar = fileName; // Gán đường dẫn avatar vào đối tượng người dùng
            }

            // Cập nhật thông tin người dùng
            userManager.Update(user);
            appDBContext.SaveChanges();
            return RedirectToAction("BangNguoiDung");
        }


        public ActionResult XemNguoiDung(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);
            NguoiDung user = userManager.FindById(id.ToString());
            var role = userManager.GetRoles(user.Id);
            ViewBag.Role = role[0];
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        public ActionResult XoaNguoiDung(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);
            NguoiDung user = userManager.FindById(id.ToString());
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult XoaNguoiDung(FormCollection c)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);
            NguoiDung user = userManager.FindById(c["Id"]);
            if (user == null)
            {
                return HttpNotFound();
            }
            userManager.Delete(user);
            appDBContext.SaveChanges();
            return RedirectToAction("BangNguoiDung");
        }

        [HttpPost]
        
        public ActionResult TimKiemTheoEmail(FormCollection c)
        {
            string str_search = c["txtSearch"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);
            List<NguoiDung> users = userManager.Users.Where(u => u.Email.Contains(str_search)).ToList();
            var NguoiDungVaiTro = new List<NguoiDungVaiTroVM>();
            foreach (var user in users) {
                var userRoles = userManager.GetRoles(user.Id);
                NguoiDungVaiTroVM userVM = new NguoiDungVaiTroVM()
                {
                    Id = user.Id,
                    Email = user.Email,
                    TenNguoiDung = user.UserName,
                    DiaChi = user.DiaChi,
                    SoDienThoai = user.PhoneNumber,
                    VaiTro = userRoles[0]
                };
                NguoiDungVaiTro.Add(userVM);
            }
            return View("BangNguoiDung", NguoiDungVaiTro);
        }
    }
}
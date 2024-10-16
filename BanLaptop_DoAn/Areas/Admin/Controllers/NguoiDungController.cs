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
    }
}
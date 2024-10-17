using BanLaptop_DoAn.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BanLaptop_DoAn.ViewModel;
using System.Web.UI.WebControls;

namespace BanLaptop_DoAn.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rvm)
        {
            if (ModelState.IsValid)
            {
                var appDBContext = new AppDbContext();
                var userStore = new LuuTruNguoiDung(appDBContext);
                var userManager = new QuanLyNguoiDung(userStore);
                var passwordHash = Crypto.HashPassword(rvm.MatKhau);
                var user = new NguoiDung()
                {
                    Email = rvm.Email,
                    UserName = rvm.TenNguoiDung,
                    PasswordHash = passwordHash,
                };
                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM lvm)
        {
            var appDBContext = new AppDbContext();
            var userStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(userStore);
            var user = userManager.Find(lvm.TenNguoiDung, lvm.MatKhau);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                if (userManager.IsInRole(user.Id, "Admin") || userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "TrangChu", new { area = "Admin" });
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Login Error", "Tên người dùng hoặc mật khẩu không đúng");
                return View();
            }

        }

        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
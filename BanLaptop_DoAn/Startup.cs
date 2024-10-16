using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using BanLaptop_DoAn.Identity;
using System.Web.Services.Description;
using Microsoft.Extensions.DependencyInjection;

[assembly: OwinStartup(typeof(BanLaptop_DoAn.Startup))]

namespace BanLaptop_DoAn
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/TaiKhoan/Login")
            });
            CreateRolesandUsers();
        }

        public void CreateRolesandUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDBContext = new AppDbContext();
            var appUserStore = new LuuTruNguoiDung(appDBContext);
            var userManager = new QuanLyNguoiDung(appUserStore);

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (userManager.FindByName("admin")==null)
            {
                var user = new NguoiDung();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPwd = "123456";

                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            if (userManager.FindByName("manager") == null)
            {
                var user = new NguoiDung();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                string userPwd = "123456";

                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}

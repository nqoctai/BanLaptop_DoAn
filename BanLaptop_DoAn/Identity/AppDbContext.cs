using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BanLaptop_DoAn.Identity
{
    public class AppDbContext : IdentityDbContext<NguoiDung>
    {
        public AppDbContext() : base("name=LaptopShopDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Đổi tên bảng AspNetUsers
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");

            // Đổi tên bảng AspNetRoles
            modelBuilder.Entity<IdentityRole>().ToTable("VaiTro");

            // Đổi tên bảng AspNetUserLogins
            modelBuilder.Entity<IdentityUserLogin>().ToTable("DangNhapNguoiDung");

            // Đổi tên bảng AspNetUserRoles
            modelBuilder.Entity<IdentityUserRole>().ToTable("VaiTroNguoiDung");



            modelBuilder.Entity<NguoiDung>().Property(e => e.UserName).HasColumnName("TenNguoiDung");
            modelBuilder.Entity<NguoiDung>().Property(e => e.EmailConfirmed).HasColumnName("XacNhanEmail");
            modelBuilder.Entity<NguoiDung>().Property(e => e.PasswordHash).HasColumnName("MatKhau");
            modelBuilder.Entity<NguoiDung>().Property(e => e.PhoneNumber).HasColumnName("SoDienThoai");


            modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasColumnName("TenVaiTro");
            modelBuilder.Entity<IdentityUserRole>().Property(r => r.UserId).HasColumnName("IdNguoiDung");
            modelBuilder.Entity<IdentityUserRole>().Property(r => r.RoleId).HasColumnName("IdVaiTro");


        }
    }
}
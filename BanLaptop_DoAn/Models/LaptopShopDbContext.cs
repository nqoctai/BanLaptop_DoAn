using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BanLaptop_DoAn.Models
{
    public class LaptopShopDbContext : DbContext
    {
        public LaptopShopDbContext() : base("name=LaptopShopDbContext")
        {
        }
        public DbSet<SanPham> SanPhams { get; set; }

        public DbSet<ThuongHieu> ThuongHieus { get; set; }

        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

        public DbSet<MucDichSuDung> MucDichSuDungs { get; set; }
    }
}
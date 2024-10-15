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
    }
}
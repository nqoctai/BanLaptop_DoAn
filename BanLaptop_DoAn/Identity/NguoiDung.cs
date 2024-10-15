using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BanLaptop_DoAn.Identity
{
    public class NguoiDung : IdentityUser
    {
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string HoVaTen { get; set; }
    }
}
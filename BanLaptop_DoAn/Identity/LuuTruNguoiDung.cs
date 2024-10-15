using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BanLaptop_DoAn.Identity
{
    public class LuuTruNguoiDung  : UserStore<NguoiDung>
    {
        public LuuTruNguoiDung(AppDbContext context) : base(context)
        {
        }
    }
}
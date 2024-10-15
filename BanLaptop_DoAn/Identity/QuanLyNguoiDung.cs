using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BanLaptop_DoAn.Identity
{
    public class QuanLyNguoiDung : UserManager<NguoiDung>
    {
        public QuanLyNguoiDung(IUserStore<NguoiDung> store) : base(store)
        {
        }
    }
}
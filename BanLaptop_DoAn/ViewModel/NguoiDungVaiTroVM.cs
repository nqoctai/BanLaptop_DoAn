using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanLaptop_DoAn.ViewModel
{
    public class NguoiDungVaiTroVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string TenNguoiDung { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }


        public string VaiTro { get; set; } // Được sử dụng để hiển thị vai trò duy nhất
    }
}
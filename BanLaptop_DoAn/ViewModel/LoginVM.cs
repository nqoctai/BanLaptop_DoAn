using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanLaptop_DoAn.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string TenNguoiDung { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string MatKhau { get; set; }
    }
}
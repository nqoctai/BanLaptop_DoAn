using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanLaptop_DoAn.Models
{
    public class SanPham
    {

        [Key]
        public long ID { get; set; }
        public string Ten { get; set; }
        public double Gia { get; set; }
        public string HinhAnh { get; set; }

        public string MoTaChiTiet { get; set; }

        public string MoTaNgan { get; set; }

        public long SoLuong { get; set; }
        public long DaBan { get; set; }
        public string ThuongHieu { get; set; }
        public string PhanKhucSanPham { get; set; }
    }
}
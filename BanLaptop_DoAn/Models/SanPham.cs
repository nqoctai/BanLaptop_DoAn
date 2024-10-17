using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanLaptop_DoAn.Models
{
    [Table("SanPhams")]
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
        [Required]
        public long ThuongHieuId { get; set; }

        [Required]
        public long LoaiSanPhamId { get; set; }

        public long MucDichSuDungId { get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual MucDichSuDung MucDichSuDung { get; set; }
    }
}
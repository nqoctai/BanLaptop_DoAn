using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanLaptop_DoAn.Models
{
    [Table("ThuongHieus")]
    public class ThuongHieu
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string TenThuongHieu { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
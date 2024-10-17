using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanLaptop_DoAn.Models
{
    [Table("MucDichSuDungs")]
    public class MucDichSuDung
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string TenMucDich { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
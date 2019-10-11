namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(50)]
        public string UserNameNhanVien { get; set; }

        [StringLength(10)]
        public string IdNhomNhanVien { get; set; }

        [StringLength(50)]
        public string PasswordNhanVien { get; set; }

        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [StringLength(50)]
        public string DiaChiNhanVien { get; set; }

        [StringLength(11)]
        public string SoDienThoaiNhanVien { get; set; }

        [StringLength(11)]
        public string ChungMinhNhanDanNhanVien { get; set; }

        [StringLength(20)]
        public string EmailNhanVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinhNhanVien { get; set; }

        [StringLength(5)]
        public string GioiTinhNhanVien { get; set; }

        public virtual NhomNhanVien NhomNhanVien { get; set; }
    }
}

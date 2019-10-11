namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quyen_NV
    {
        public int id { get; set; }

        [StringLength(10)]
        public string IdQuyen { get; set; }

        [StringLength(10)]
        public string IdNhomNhanVien { get; set; }

        public virtual NhomNhanVien NhomNhanVien { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}

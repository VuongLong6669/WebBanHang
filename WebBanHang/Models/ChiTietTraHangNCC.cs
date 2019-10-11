namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietTraHangNCC")]
    public partial class ChiTietTraHangNCC
    {
        public int Id { get; set; }

        public int? SoLuongTraHang { get; set; }

        [StringLength(50)]
        public string LyDoTraHang { get; set; }

        public int? IdHangHoa { get; set; }

        public int? IdTraHangNCC { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual TraHangNCC TraHangNCC { get; set; }
    }
}

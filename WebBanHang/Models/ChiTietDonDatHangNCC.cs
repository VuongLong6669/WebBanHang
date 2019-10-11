namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonDatHangNCC")]
    public partial class ChiTietDonDatHangNCC
    {
        public int Id { get; set; }

        public int? IdHangHoa { get; set; }

        public int? IdDonDatHangNhaCungCap { get; set; }

        public int? SoLuongDatHangNCC { get; set; }

        public double? DonGiaNhap { get; set; }

        public virtual DonDatHangNCC DonDatHangNCC { get; set; }

        public virtual HangHoa HangHoa { get; set; }
    }
}

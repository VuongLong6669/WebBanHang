namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonDatHang")]
    public partial class ChiTietDonDatHang
    {
        public int Id { get; set; }

        public int? IdHangHoa { get; set; }

        public int? IdDonDatHang { get; set; }

        public int? SoLuongDatHang { get; set; }

        public double? DonGiaDatHang { get; set; }

        public virtual DonDatHang DonDatHang { get; set; }

        public virtual HangHoa HangHoa { get; set; }
    }
}

namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ChiTietDonDatHangNCCs = new HashSet<ChiTietDonDatHangNCC>();
            ChiTietTraHangNCCs = new HashSet<ChiTietTraHangNCC>();
        }

        [Key]
        public int IdHangHoa { get; set; }

        [StringLength(50)]
        public string TenHangHoa { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string DVT { get; set; }

        [StringLength(150)]
        public string Anh { get; set; }

        public double? DonGiaBan { get; set; }

        public int? IdLoaiHang { get; set; }

        public int? IdVoucher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHangNCC> ChiTietDonDatHangNCCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTraHangNCC> ChiTietTraHangNCCs { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual LoaiHang LoaiHang { get; set; }
    }
}

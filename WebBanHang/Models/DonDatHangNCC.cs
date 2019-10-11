namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHangNCC")]
    public partial class DonDatHangNCC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHangNCC()
        {
            ChiTietDonDatHangNCCs = new HashSet<ChiTietDonDatHangNCC>();
            TraHangNCCs = new HashSet<TraHangNCC>();
        }

        [Key]
        public int IdDonDatHangNhaCungCap { get; set; }

        public DateTime? NgayDatHangNhaCungCap { get; set; }

        [StringLength(50)]
        public string DiaChiGiaoHang { get; set; }

        [StringLength(50)]
        public string ThoiGianGiaoHang { get; set; }

        [StringLength(50)]
        public string HinhThucThanhToan { get; set; }

        public bool? TinhTrangDonDatHangNCC { get; set; }

        public double? TongTienDonDatHangNCC { get; set; }

        public int? IdNhaCungCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHangNCC> ChiTietDonDatHangNCCs { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraHangNCC> TraHangNCCs { get; set; }
    }
}

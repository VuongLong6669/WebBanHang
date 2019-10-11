namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            DonDatHangNCCs = new HashSet<DonDatHangNCC>();
        }

        [Key]
        public int IdNhaCungCap { get; set; }

        [StringLength(50)]
        public string TenNhaCungCap { get; set; }

        [StringLength(20)]
        public string SoTaiKhoanNhaCungCap { get; set; }

        [StringLength(50)]
        public string DiaChiNhaCungCap { get; set; }

        [StringLength(50)]
        public string SoDienThoaiNhaCungCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHangNCC> DonDatHangNCCs { get; set; }
    }
}

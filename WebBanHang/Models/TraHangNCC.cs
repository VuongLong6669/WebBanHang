namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraHangNCC")]
    public partial class TraHangNCC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TraHangNCC()
        {
            ChiTietTraHangNCCs = new HashSet<ChiTietTraHangNCC>();
        }

        [Key]
        public int IdTraHangNCC { get; set; }

        [StringLength(50)]
        public string ThoiGianTraHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTraHang { get; set; }

        public int? IdDonDatHangNhaCungCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTraHangNCC> ChiTietTraHangNCCs { get; set; }

        public virtual DonDatHangNCC DonDatHangNCC { get; set; }
    }
}

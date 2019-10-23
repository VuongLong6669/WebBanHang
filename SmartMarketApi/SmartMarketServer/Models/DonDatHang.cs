using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class DonDatHang
    {
        public DonDatHang()
        {
            ChiTietDonDatHang = new HashSet<ChiTietDonDatHang>();
        }

        public int IdDonDatHang { get; set; }
        public DateTime? NgayTaoDonDatHang { get; set; }
        public string DiaChiNhanHang { get; set; }
        public DateTime? ThoiGianNhanHang { get; set; }
        public bool? TrangThaiDonDatHang { get; set; }
        public int? IdKhachHang { get; set; }
        public string GhiChu { get; set; }

        public KhachHang IdKhachHangNavigation { get; set; }
        public ICollection<ChiTietDonDatHang> ChiTietDonDatHang { get; set; }
    }
}

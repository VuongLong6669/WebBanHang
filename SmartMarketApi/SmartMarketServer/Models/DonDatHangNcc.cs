using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class DonDatHangNcc
    {
        public DonDatHangNcc()
        {
            ChiTietDonDatHangNcc = new HashSet<ChiTietDonDatHangNcc>();
            TraHangNcc = new HashSet<TraHangNcc>();
        }

        public int IdDonDatHangNhaCungCap { get; set; }
        public DateTime? NgayDatHangNhaCungCap { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string ThoiGianGiaoHang { get; set; }
        public string HinhThucThanhToan { get; set; }
        public bool? TinhTrangDonDatHangNcc { get; set; }
        public int? IdNhaCungCap { get; set; }

        public NhaCungCap IdNhaCungCapNavigation { get; set; }
        public ICollection<ChiTietDonDatHangNcc> ChiTietDonDatHangNcc { get; set; }
        public ICollection<TraHangNcc> TraHangNcc { get; set; }
    }
}

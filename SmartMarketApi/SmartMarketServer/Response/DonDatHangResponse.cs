using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMarketServer.Response
{
    public class DonDatHangResponse
    {
        public int IdDonDatHang { get; set; }
        public DateTime? NgayTaoDonDatHang { get; set; }
        public string DiaChiNhanHang { get; set; }
        public DateTime? ThoiGianNhanHang { get; set; }
        public int? TrangThaiDonDatHang { get; set; }
        public int? IdKhachHang { get; set; }
        public string GhiChu { get; set; }
        public double? TongTien { get; set; }

        public List<ChiTietDatHangResponse> listChiTiet;
    }
}

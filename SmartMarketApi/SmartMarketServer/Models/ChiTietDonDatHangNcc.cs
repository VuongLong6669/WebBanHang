using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class ChiTietDonDatHangNcc
    {
        public int Id { get; set; }
        public int? IdHangHoa { get; set; }
        public int? IdDonDatHangNhaCungCap { get; set; }
        public int? SoLuongDatHangNcc { get; set; }
        public double? DonGiaNhap { get; set; }

        public DonDatHangNcc IdDonDatHangNhaCungCapNavigation { get; set; }
        public HangHoa IdHangHoaNavigation { get; set; }
    }
}

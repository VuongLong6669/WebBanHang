using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class ChiTietDonDatHang
    {
        public int Id { get; set; }
        public int? IdHangHoa { get; set; }
        public int? IdDonDatHang { get; set; }
        public int? SoLuongDatHang { get; set; }
        public double? DonGiaDatHang { get; set; }

        public DonDatHang IdDonDatHangNavigation { get; set; }
        public HangHoa IdHangHoaNavigation { get; set; }
    }
}

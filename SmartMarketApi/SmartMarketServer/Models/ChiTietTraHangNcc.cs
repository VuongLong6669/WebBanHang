using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class ChiTietTraHangNcc
    {
        public int Id { get; set; }
        public int? SoLuongTraHang { get; set; }
        public string LyDoTraHang { get; set; }
        public int? IdHangHoa { get; set; }
        public int? IdTraHangNcc { get; set; }

        public HangHoa IdHangHoaNavigation { get; set; }
        public TraHangNcc IdTraHangNccNavigation { get; set; }
    }
}

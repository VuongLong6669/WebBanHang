using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class TraHangNcc
    {
        public TraHangNcc()
        {
            ChiTietTraHangNcc = new HashSet<ChiTietTraHangNcc>();
        }

        public int IdTraHangNcc { get; set; }
        public string ThoiGianTraHang { get; set; }
        public DateTime? NgayTraHang { get; set; }
        public int? IdDonDatHangNhaCungCap { get; set; }

        public DonDatHangNcc IdDonDatHangNhaCungCapNavigation { get; set; }
        public ICollection<ChiTietTraHangNcc> ChiTietTraHangNcc { get; set; }
    }
}

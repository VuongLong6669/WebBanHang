using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonDatHang = new HashSet<DonDatHang>();
        }

        public int IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoaiKhachHang { get; set; }
        public string EmailKhachHang { get; set; }
        public string DiaChiKhachHang { get; set; }
        public DateTime? NgaySinhKhachHang { get; set; }
        public string GioiTinhKhachHang { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public int? IdLevel { get; set; }

        public Level IdLevelNavigation { get; set; }
        public ICollection<DonDatHang> DonDatHang { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class Level
    {
        public Level()
        {
            KhachHang = new HashSet<KhachHang>();
            KhuyenMai = new HashSet<KhuyenMai>();
        }

        public int IdLevel { get; set; }
        public string TenLevel { get; set; }

        public ICollection<KhachHang> KhachHang { get; set; }
        public ICollection<KhuyenMai> KhuyenMai { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class KhuyenMai
    {
        public KhuyenMai()
        {
            HangHoa = new HashSet<HangHoa>();
        }

        public int IdVoucher { get; set; }
        public string TenVoucher { get; set; }
        public DateTime? NgayTaoVoucher { get; set; }
        public string MoTaVoucher { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public double? PhanTramKhuyenMai { get; set; }
        public int? IdLevel { get; set; }

        public Level IdLevelNavigation { get; set; }
        public ICollection<HangHoa> HangHoa { get; set; }
    }
}

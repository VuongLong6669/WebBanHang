using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class LoaiHang
    {
        public LoaiHang()
        {
            HangHoa = new HashSet<HangHoa>();
        }

        public int IdLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }
        public string Anh { get; set; }
        public ICollection<HangHoa> HangHoa { get; set; }
    }
}

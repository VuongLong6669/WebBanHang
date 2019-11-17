using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class ThuocTinh
    {
        public ThuocTinh()
        {
            ThuocTinhHangHoa = new HashSet<ThuocTinhHangHoa>();
        }

        public int Id { get; set; }
        public string TenThuocTinh { get; set; }

        public ICollection<ThuocTinhHangHoa> ThuocTinhHangHoa { get; set; }
    }
}

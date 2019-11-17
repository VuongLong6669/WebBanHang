using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class ThuocTinhHangHoa
    {
        public int Id { get; set; }
        public int IdThuocTinh { get; set; }
        public int IdHangHoa { get; set; }
        public string GiaTri { get; set; }

        public HangHoa IdHangHoaNavigation { get; set; }
        public ThuocTinh IdThuocTinhNavigation { get; set; }
    }
}

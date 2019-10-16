using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            DonDatHangNcc = new HashSet<DonDatHangNcc>();
        }

        public int IdNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SoTaiKhoanNhaCungCap { get; set; }
        public string DiaChiNhaCungCap { get; set; }
        public string SoDienThoaiNhaCungCap { get; set; }

        public ICollection<DonDatHangNcc> DonDatHangNcc { get; set; }
    }
}

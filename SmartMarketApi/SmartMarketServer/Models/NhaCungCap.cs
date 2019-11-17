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
        public string Ten { get; set; }
        public string SoTaiKhoan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string NganHang { get; set; }

        public ICollection<DonDatHangNcc> DonDatHangNcc { get; set; }
    }
}

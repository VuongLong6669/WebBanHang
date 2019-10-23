using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class NhanVien
    {
        public string UserNameNhanVien { get; set; }
        public string IdNhomNhanVien { get; set; }
        public string PasswordNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string DiaChiNhanVien { get; set; }
        public string SoDienThoaiNhanVien { get; set; }
        public string ChungMinhNhanDanNhanVien { get; set; }
        public string EmailNhanVien { get; set; }
        public DateTime? NgaySinhNhanVien { get; set; }
        public string GioiTinhNhanVien { get; set; }
        public bool? TrangThaiNhanVien { get; set; }

        public NhomNhanVien IdNhomNhanVienNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class QuyenNv
    {
        public int Id { get; set; }
        public string IdQuyen { get; set; }
        public string IdNhomNhanVien { get; set; }

        public NhomNhanVien IdNhomNhanVienNavigation { get; set; }
        public Quyen IdQuyenNavigation { get; set; }
    }
}

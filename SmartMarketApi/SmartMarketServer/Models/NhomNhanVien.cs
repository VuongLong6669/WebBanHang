using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class NhomNhanVien
    {
        public NhomNhanVien()
        {
            NhanVien = new HashSet<NhanVien>();
            QuyenNv = new HashSet<QuyenNv>();
        }

        public string IdNhomNhanVien { get; set; }
        public string TenNhomNhanVien { get; set; }

        public ICollection<NhanVien> NhanVien { get; set; }
        public ICollection<QuyenNv> QuyenNv { get; set; }
    }
}

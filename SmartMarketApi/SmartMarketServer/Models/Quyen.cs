using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class Quyen
    {
        public Quyen()
        {
            QuyenNv = new HashSet<QuyenNv>();
        }

        public string IdQuyen { get; set; }
        public string TenQuyen { get; set; }

        public ICollection<QuyenNv> QuyenNv { get; set; }
    }
}

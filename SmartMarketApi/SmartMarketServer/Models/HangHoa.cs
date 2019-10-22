using System;
using System.Collections.Generic;

namespace SmartMarketServer.Models
{
    public partial class HangHoa
    {
        public HangHoa()
        {
            ChiTietDonDatHang = new HashSet<ChiTietDonDatHang>();
            ChiTietDonDatHangNcc = new HashSet<ChiTietDonDatHangNcc>();
            ChiTietTraHangNcc = new HashSet<ChiTietTraHangNcc>();
        }

        public int IdHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int? SoLuong { get; set; }
        public string Dvt { get; set; }
        public string Anh { get; set; }
        public double? DonGiaBan { get; set; }
        public int? IdLoaiHang { get; set; }
        public int? IdVoucher { get; set; }
        public string MoTaHangHoa { get; set; }
        public DateTime? CreateDate { get; set; }
        public LoaiHang IdLoaiHangNavigation { get; set; }
        public KhuyenMai IdVoucherNavigation { get; set; }
        public ICollection<ChiTietDonDatHang> ChiTietDonDatHang { get; set; }
        public ICollection<ChiTietDonDatHangNcc> ChiTietDonDatHangNcc { get; set; }
        public ICollection<ChiTietTraHangNcc> ChiTietTraHangNcc { get; set; }
    }
}

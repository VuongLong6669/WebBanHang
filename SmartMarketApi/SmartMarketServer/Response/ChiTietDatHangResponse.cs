using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMarketServer.Response
{
    public class ChiTietDatHangResponse
    {
        public int Id { get; set; }
        public int? IdHangHoa { get; set; }
        public int? IdDonDatHang { get; set; }
        public int? SoLuongDatHang { get; set; }
        public double? DonGiaDatHang { get; set; }
    }
}

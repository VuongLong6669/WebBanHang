using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMarketServer.Requests
{
    public class CreateKHRequest
    {
        public string TenKhachHang { get; set; }
        public string SoDienThoaiKhachHang { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
    }
}

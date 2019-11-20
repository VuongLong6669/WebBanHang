using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMarketServer.Requests
{
    public class EditKHRequest
    {
        public int Id { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoaiKhachHang { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }
}

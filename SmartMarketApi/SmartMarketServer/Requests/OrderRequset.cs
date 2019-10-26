using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMarketServer.Requests
{
    public class OrderRequset
    {
        public int idKhachHang;
        public List<int> khuyenMais;
        public List<OrderDetailRequest> listOrdetail;
    }
}

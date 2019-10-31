using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMarketServer.Requests
{
    public class OrderRequset
    {
        public int idKhachHang;
        public String address;
        public DateTime timeGetProduct;
        public String note;
        public List<int> khuyenMais;
        public List<OrderDetailRequest> listOrdetail;
    }
}

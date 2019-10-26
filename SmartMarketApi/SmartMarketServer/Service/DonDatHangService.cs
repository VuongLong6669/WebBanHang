using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMarketServer.Response;
using SmartMarketServer.Requests;

namespace SmartMarketServer.Service
{
    public class DonDatHangService
    {
        public BaseResponse createOrder(OrderRequset request)
        {
            BaseResponse response = new BaseResponse();
            response.code = "200";
            response.message = "Thêm đơn hàng thành công";
            return response;
        }
    }
}

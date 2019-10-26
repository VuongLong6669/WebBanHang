using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMarketServer.Models;

namespace SmartMarketServer.Response
{
    public class LoginResponse : BaseResponse
    {
        public KhachHang account;
    }
}

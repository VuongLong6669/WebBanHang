using SmartMarketServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartMarketServer.Response;
using System.Threading.Tasks;

namespace SmartMarketServer.Service
{
    public class ProductService
    {
        QuanLyBanHangSieuThiMediaMartContext conext = new QuanLyBanHangSieuThiMediaMartContext();
        public BaseResponse findNewProduct(int top)
        {
            ListMatHangResponse response = new ListMatHangResponse();
            
            StringBuilder sql = new StringBuilder();
            //sql.Append("select top ");
            //sql.Append(top);
            //sql.Append(" * from dbo.hanghoa order by HangHoa.CreateDate");
            //HangHoa ha1 = new HangHoa();
            //ha1.TenHangHoa = "Hang hoa 1";
            //ha1.SoLuong = 4;
            response.setCode(BaseResponse.CODE_SUCESS);
            response.setMessage("Thành công");
            List<HangHoa> lHH = conext.HangHoa.OrderBy(a => a.CreateDate).Take(top).ToList<HangHoa>();
            response.listHH = lHH;
            return response;
            //List<HangHoa> list  = conext.HangHoa.ToList<HangHoa>();
            //return list;
        }
    }
}

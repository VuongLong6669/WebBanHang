using SmartMarketServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMarketServer.Service
{
    public class ProductService
    {
        QuanLyBanHangSieuThiMediaMartContext conext = new QuanLyBanHangSieuThiMediaMartContext();
        public List<HangHoa> findNewProduct(int top)
        {
            StringBuilder sql = new StringBuilder();
            //sql.Append("select top ");
            //sql.Append(top);
            //sql.Append(" * from dbo.hanghoa order by HangHoa.CreateDate");
            //HangHoa ha1 = new HangHoa();
            //ha1.TenHangHoa = "Hang hoa 1";
            //ha1.SoLuong = 4;
            return conext.HangHoa.OrderBy(a => a.CreateDate).Take(top).ToList<HangHoa>();
            //List<HangHoa> list  = conext.HangHoa.ToList<HangHoa>();
            //return list;
        }
    }
}

using SmartMarketServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartMarketServer.Response;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace SmartMarketServer.Service
{
    public class ProductService
    {
        QuanLyBanHangSieuThiMediaMartContext context = new QuanLyBanHangSieuThiMediaMartContext();
        public ListMatHangResponse findNewProduct(int top)
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
            List<HangHoa> lHH = context.HangHoa.OrderBy(a => a.CreateDate).Take(top).ToList<HangHoa>();
            response.listHH = lHH;
            return response;
            //List<HangHoa> list  = conext.HangHoa.ToList<HangHoa>();
            //return list;
        }

        public List<HangHoa> findByListID(List<int> listIds)
        {
            List<HangHoa> lHH = new List<HangHoa>();
            foreach (int id in listIds)
            {
                HangHoa hh = context.HangHoa.Where(a => a.IdHangHoa == id).First();
                if (hh != null)
                {
                    lHH.Add(hh);
                }
            }
            return lHH;
        }

        public List<HangHoa> searchProduct(String searchText)
        {

            List<HangHoa> lHH = new List<HangHoa>();
            lHH.Add(context.HangHoa.Find(13));
            if (searchText == null)
            {
                return lHH;
            }

            //lHH = (from c in context.HangHoa
            // where SqlMethods.Like(c.TenHangHoa, "'%" + searchText + "%'")
            //       select c).ToList();
            return lHH;
        }
    }
}

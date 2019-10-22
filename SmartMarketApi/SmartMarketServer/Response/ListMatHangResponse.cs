using SmartMarketServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMarketServer.Response
{
    public class ListMatHangResponse : BaseResponse
    {
        public List<HangHoa> listHH;

        public List<HangHoa> getListHH()
        {
            return listHH;
        }

        public void setListHH(List<HangHoa> lHH)
        {
           this.listHH = lHH;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartMarketServer.Models;

namespace SmartMarketServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        QuanLyBanHangSieuThiMediaMartContext context = new QuanLyBanHangSieuThiMediaMartContext();
        // GET api/values
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<List<ChiTietDonDatHang>> Get()
        {
            var hanghoa = new HangHoa();
            return Ok(hanghoa);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMarketServer.Models;
using SmartMarketServer.Service;
using SmartMarketServer.Response;
namespace SmartMarketServer.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class HangHoasController : ControllerBase
    {
        private readonly QuanLyBanHangSieuThiMediaMartContext _context;
        private ProductService service;
        public HangHoasController(QuanLyBanHangSieuThiMediaMartContext context)
        {
            _context = context;
            service = new ProductService();
        }


        // GET: api/HangHoas
        [HttpGet]
        [Route("get-all")]
        public ActionResult<List<HangHoa>> GetHangHoa()
        {
            var listHH = _context.HangHoa.ToList<HangHoa>();
            List<HangHoaResponse> responses = new List<HangHoaResponse>();
            foreach (HangHoa hh in listHH)
            {
                responses.Add(setHangHoa(hh));
            }
            var response = responses;
            return Ok(response);
        }

        [HttpGet]
        [Route("search-product/{search_text}")]
        public ActionResult<List<HangHoa>> search([FromRoute] string search_text)
        {
            var listHH = service.searchProduct(search_text);
            List<HangHoaResponse> responses = new List<HangHoaResponse>();
            foreach (HangHoa hh in listHH)
            {
                responses.Add(setHangHoa(hh));
            }
            var response = responses;
            return Ok(response);
        }

        [HttpGet]
        [Route("get-by-cate/{id}")]
        public ActionResult<List<HangHoa>> GetByCate([FromRoute] int id)
        {
            var listHH = _context.HangHoa.Where( a => a.IdLoaiHang == id).ToList<HangHoa>();
            List<HangHoaResponse> responses = new List<HangHoaResponse>();
            foreach (HangHoa hh in listHH)
            {
                responses.Add(setHangHoa(hh));
            }
            var response = responses;
            return Ok(response);
        }

        [HttpGet]
        [Route("get-new/{count}")]
        public ActionResult<BaseResponse> GetNewsHangHoa([FromRoute] int count)
        {
            var listHH = _context.HangHoa.OrderBy(a => a.CreateDate).Take(count).ToList<HangHoa>();
            List<HangHoaResponse> responses = new List<HangHoaResponse>();
            foreach (HangHoa hh in listHH)
            {
                responses.Add(setHangHoa(hh));
            }
            var response = responses;
            return Ok(response);
        }

        [HttpGet]
        [Route("get-discounts/{count}")]
        public ActionResult<BaseResponse> GetDiscounts([FromRoute] int count)
        {
            List<HangHoa> listHH = _context.HangHoa.OrderBy(a => a.CreateDate).Where(a=>a.GiaMoi>a.DonGiaBan).Take(count).ToList<HangHoa>();
            List<HangHoaResponse> responses = new List<HangHoaResponse>();
            foreach(HangHoa hh in listHH)
            {
                responses.Add(setHangHoa(hh));
            }
            var response = responses;
            return Ok(response);
        }

        // GET: api/HangHoas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHangHoa([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HangHoa hangHoa = await _context.HangHoa.FindAsync(id);
            
            if (hangHoa == null)
            {
                return NotFound();
            }
            var response = setHangHoa(hangHoa);
            return Ok(response);
        }

        // PUT: api/HangHoas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHangHoa([FromRoute] int id, [FromBody] HangHoa hangHoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hangHoa.IdHangHoa)
            {
                return BadRequest();
            }

            _context.Entry(hangHoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangHoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HangHoas
        [HttpPost]
        public async Task<IActionResult> PostHangHoa([FromBody] HangHoa hangHoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HangHoa.Add(hangHoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHangHoa", new { id = hangHoa.IdHangHoa }, hangHoa);
        }

        // DELETE: api/HangHoas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHangHoa([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hangHoa = await _context.HangHoa.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            _context.HangHoa.Remove(hangHoa);
            await _context.SaveChangesAsync();

            return Ok(hangHoa);
        }

        private HangHoaResponse setHangHoa(HangHoa hangHoa)
        {
            HangHoaResponse response = new HangHoaResponse();
            List<ThuocTinhResponse> lisTTResponse = new List<ThuocTinhResponse>();
            List<ThuocTinhHangHoa> listTT = _context.ThuocTinhHangHoa.Where(a => a.IdHangHoa == hangHoa.IdHangHoa).ToList();
            foreach(ThuocTinhHangHoa tthh in listTT)
            {
                ThuocTinh tt = _context.ThuocTinh.Find(tthh.IdThuocTinh);
                ThuocTinhResponse ttRP = new ThuocTinhResponse();
                if (tt != null)
                {
                    ttRP.name = tt.TenThuocTinh;
                }
                ttRP.detail = tthh.GiaTri;
                lisTTResponse.Add(ttRP);
            }
            response.hangHoa = hangHoa;
            response.listTT = lisTTResponse;
            return response;
        }

        private bool HangHoaExists(int id)
        {
            return _context.HangHoa.Any(e => e.IdHangHoa == id);

        }
    }
}
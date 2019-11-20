using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMarketServer.Models;
using SmartMarketServer.Requests;
using SmartMarketServer.Response;
using SmartMarketServer.Service;

namespace SmartMarketServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangsController : ControllerBase
    {
        private readonly QuanLyBanHangSieuThiMediaMartContext _context;
        private readonly KhachHangService service;
        public KhachHangsController(QuanLyBanHangSieuThiMediaMartContext context)
        {
            _context = context;
            service = new KhachHangService(_context);
        }

        // GET: api/KhachHangs
        [HttpGet]
        public IEnumerable<KhachHang> GetKhachHang()
        {
            return _context.KhachHang;
        }

        // GET: api/KhachHangs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhachHang([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var khachHang = await _context.KhachHang.FindAsync(id);

            if (khachHang == null)
            {
                return NotFound();
            }

            return Ok(khachHang);
        }

        // PUT: api/KhachHangs/5
        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> PutKhachHang([FromBody] EditKHRequest khach_hang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (khach_hang == null)
            {
                return BadRequest();
            }

            KhachHang khachHang = _context.KhachHang.Find(khach_hang.Id);
            if (checkNullAndEmpty(khach_hang.Address))
            {
                khachHang.DiaChiKhachHang = khach_hang.Address;
            }

            if (checkNullAndEmpty(khach_hang.Email))
            {
                khachHang.EmailKhachHang = khach_hang.Email;
            }

            if (checkNullAndEmpty(khach_hang.SoDienThoaiKhachHang))
            {
                khachHang.SoDienThoaiKhachHang = khach_hang.SoDienThoaiKhachHang;
            }

            if (checkNullAndEmpty(khach_hang.TenKhachHang))
            {
                khachHang.TenKhachHang = khach_hang.TenKhachHang;
            }

            if (checkNullAndEmpty(khach_hang.Password))
            {
                khachHang.Password = khach_hang.Password;
            }
            _context.Entry(khachHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachHangExists(khach_hang.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(khachHang);
        }

        // POST: api/KhachHangs
        [HttpGet]
        [Route("login")]
        public ActionResult<LoginResponse> login([FromQuery] String userName, [FromQuery] String passWord )
        {

            var loginResponse = service.login(userName, passWord);
            return Ok(loginResponse);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> PostKhachHang([FromBody] CreateKHRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            KhachHang khachHang = service.CreateKhachHang(request);
            return CreatedAtAction("GetKhachHang", new { id = khachHang.IdKhachHang }, khachHang);
        }

        // DELETE: api/KhachHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachHang([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            _context.KhachHang.Remove(khachHang);
            await _context.SaveChangesAsync();

            return Ok(khachHang);
        }

        private bool KhachHangExists(int id)
        {
            return _context.KhachHang.Any(e => e.IdKhachHang == id);
        }

        private Boolean checkNullAndEmpty(string value)
        {
            return (value != null && value != "");
        }
    }
}
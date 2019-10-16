using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMarketServer.Models;

namespace SmartMarketServer.Controllers
{
    [Route("api/cate")]
    [ApiController]
    public class LoaiHangsController : ControllerBase
    {
        private readonly QuanLyBanHangSieuThiMediaMartContext _context;

        public LoaiHangsController(QuanLyBanHangSieuThiMediaMartContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("getall")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<List<LoaiHang>> getAll()
        {
          var listHH = _context.LoaiHang.ToList();
            return Ok(listHH);
        }

        // GET: api/LoaiHangs
        [HttpGet]
        public IEnumerable<LoaiHang> GetLoaiHang()
        {
            return _context.LoaiHang;
        }

        // GET: api/LoaiHangs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoaiHang([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loaiHang = await _context.LoaiHang.FindAsync(id);

            if (loaiHang == null)
            {
                return NotFound();
            }

            return Ok(loaiHang);
        }

        // PUT: api/LoaiHangs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiHang([FromRoute] int id, [FromBody] LoaiHang loaiHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaiHang.IdLoaiHang)
            {
                return BadRequest();
            }

            _context.Entry(loaiHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiHangExists(id))
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

        // POST: api/LoaiHangs
        [HttpPost]
        public async Task<IActionResult> PostLoaiHang([FromBody] LoaiHang loaiHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LoaiHang.Add(loaiHang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiHang", new { id = loaiHang.IdLoaiHang }, loaiHang);
        }

        // DELETE: api/LoaiHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiHang([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loaiHang = await _context.LoaiHang.FindAsync(id);
            if (loaiHang == null)
            {
                return NotFound();
            }

            _context.LoaiHang.Remove(loaiHang);
            await _context.SaveChangesAsync();

            return Ok(loaiHang);
        }

        private bool LoaiHangExists(int id)
        {
            return _context.LoaiHang.Any(e => e.IdLoaiHang == id);
        }
    }
}
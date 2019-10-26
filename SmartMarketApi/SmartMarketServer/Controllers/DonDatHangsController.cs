﻿using System;
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
    public class DonDatHangsController : ControllerBase
    {
        private readonly QuanLyBanHangSieuThiMediaMartContext _context;
        private readonly DonDatHangService service;
        public DonDatHangsController(QuanLyBanHangSieuThiMediaMartContext context)
        {
            _context = context;
            service = new DonDatHangService();
        }

        // GET: api/DonDatHangs
        [HttpGet]
        public IEnumerable<DonDatHang> GetDonDatHang()
        {
            return _context.DonDatHang;
        }

        // GET: api/DonDatHangs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonDatHang([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donDatHang = await _context.DonDatHang.FindAsync(id);

            if (donDatHang == null)
            {
                return NotFound();
            }

            return Ok(donDatHang);
        }

        // PUT: api/DonDatHangs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonDatHang([FromRoute] int id, [FromBody] DonDatHang donDatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donDatHang.IdDonDatHang)
            {
                return BadRequest();
            }

            _context.Entry(donDatHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonDatHangExists(id))
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

        // POST: api/DonDatHangs
        [HttpPost]
        [Route("/add-order")]
        public ActionResult<BaseResponse> PostDonDatHang([FromBody] OrderRequset request)
        {
            var response = service.createOrder(request);
            return Ok(response);
        }

        // DELETE: api/DonDatHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonDatHang([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donDatHang = await _context.DonDatHang.FindAsync(id);
            if (donDatHang == null)
            {
                return NotFound();
            }

            _context.DonDatHang.Remove(donDatHang);
            await _context.SaveChangesAsync();

            return Ok(donDatHang);
        }

        private bool DonDatHangExists(int id)
        {
            return _context.DonDatHang.Any(e => e.IdDonDatHang == id);
        }
    }
}
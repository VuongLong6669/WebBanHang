using SmartMarketServer.Models;
using SmartMarketServer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMarketServer.Response;
namespace SmartMarketServer.Service
{
    public class KhachHangService
    {
        private readonly QuanLyBanHangSieuThiMediaMartContext _context;
        
        public KhachHangService(QuanLyBanHangSieuThiMediaMartContext context)
        {
            this._context = context;
        }
        public KhachHang CreateKhachHang(CreateKHRequest request)
        {
            if(request == null||request.UserName == null)
            {
                return null;
            }
            KhachHang khachHang = new KhachHang();
            khachHang.Username = request.UserName;
            khachHang.SoDienThoaiKhachHang = request.SoDienThoaiKhachHang;
            khachHang.TenKhachHang = request.TenKhachHang;
            khachHang.Password = request.PassWord;
            khachHang.EmailKhachHang = request.Email;
            _context.KhachHang.Add(khachHang);
            _context.SaveChangesAsync();
            return khachHang;
        }
    }
}

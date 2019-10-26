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
            _context.SaveChanges();
            return khachHang;
        }

        public LoginResponse login (String userName, String passWord)
        {
            LoginResponse response = new LoginResponse();
            if(userName == null||passWord == null)
            {
                response.code = "400";
                response.message = "Vui lòng nhập đầy đủ thông tin";
                return response;
            }
            if (!findByUserName(userName))
            {
                response.code = "404";
                response.message = "Không tìm thấy tên đăng nhập";
                return response;
            }
            KhachHang kh = _context.KhachHang.Where(a => a.Username == userName && a.Password == passWord).FirstOrDefault();
            if(kh == null)
            {
                response.code = "401";
                response.message = "Sai tên đăng nhập hoặc mật khẩu";
                return response;
            }
            response.code = "200";
            response.message = "Đăng nhập thành công";
            response.account = kh;
            return response;
        }

        private Boolean findByUserName(String userName)
        {
            KhachHang kh = _context.KhachHang.Where(a => a.Username == userName).FirstOrDefault();
            if(kh != null)
            {
                return true;
            }
            return false;
        }
    }
}

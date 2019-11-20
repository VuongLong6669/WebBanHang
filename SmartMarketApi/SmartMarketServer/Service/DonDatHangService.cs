using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMarketServer.Response;
using SmartMarketServer.Requests;
using SmartMarketServer.Models;
namespace SmartMarketServer.Service
{
  
    public class DonDatHangService
    {
        private readonly QuanLyBanHangSieuThiMediaMartContext _context;
        ProductService service;
        public DonDatHangService(QuanLyBanHangSieuThiMediaMartContext context)
        {
            this._context = context;
            service = new ProductService();
        }
        public BaseResponse createOrder(OrderRequset request)
        {
            DonDatHang donDatHang = new DonDatHang();
            donDatHang.IdKhachHang = request.idKhachHang;
            donDatHang.TrangThaiDonDatHang = false;
            donDatHang.DiaChiNhanHang = request.address;
            donDatHang.GhiChu = request.note;
            donDatHang.ThoiGianNhanHang = request.timeGetProduct;
            donDatHang.NgayTaoDonDatHang = DateTime.Now;
            BaseResponse response = new BaseResponse();
            List<int> listId = new List<int>();
            List<OrderDetailRequest> listDetailRequest = request.listOrdetail;
            foreach(OrderDetailRequest detail in listDetailRequest)
            {
                listId.Add(detail.idProduct);
            }
            List<HangHoa> listHH = service.findByListID(listId);
            double totalPrice = 0;
            foreach(OrderDetailRequest deatail in listDetailRequest)
            {
                totalPrice += findPrice(deatail.idProduct,deatail.count, listHH);
            }
            donDatHang.TongTien = totalPrice;
            _context.DonDatHang.Add(donDatHang);
            _context.SaveChanges();
            foreach(HangHoa hh in listHH)
            {
                OrderDetailRequest detail = findDetailRQ(hh.IdHangHoa, listDetailRequest);
                saveChiTietDDH(hh, detail.count, donDatHang.IdDonDatHang);
            }
            response.code = "200";
            response.message = "Thêm đơn hàng thành công";
            return response;
        }
        private double findPrice(int id ,int count,List<HangHoa> liHH)
        {
            foreach(HangHoa hh in liHH)
            {
                if(hh.IdHangHoa == id)
                {
                    return (double)(hh.GiaMoi * count);
                }
            }
            return 0;
        }
        
        private OrderDetailRequest findDetailRQ(int idHH , List<OrderDetailRequest> listHH)
        {
            foreach(OrderDetailRequest hh in listHH)
            {
                if(idHH == hh.idProduct)
                {
                    return hh;
                }
            }
            return null;
        }

        private void saveChiTietDDH(HangHoa hh,int count,int idDDH)
        {
            ChiTietDonDatHang detail = new ChiTietDonDatHang();
            detail.IdDonDatHang = idDDH;
            detail.IdHangHoa = hh.IdHangHoa;
            detail.SoLuongDatHang = count;
            detail.DonGiaDatHang = hh.GiaMoi;
            double khuyenMai = 0;
            if (hh.IdVoucher != null)
            {
                KhuyenMai km = _context.KhuyenMai.Find(hh.IdVoucher);
                if (km!=null && DateTime.Compare(km.NgayBatDau.Value,DateTime.Now)>0&&DateTime.Compare(km.NgayBatDau.Value,DateTime.Now)<0)
                {
                    if (km.PhanTramKhuyenMai != null)
                    {
                        khuyenMai = (hh.DonGiaBan.Value * km.PhanTramKhuyenMai.Value) / 100;
                    }
                }
            }
            _context.ChiTietDonDatHang.Add(detail);
            _context.SaveChanges();
        }

        public List<DonDatHangResponse> getListByCustomerId(int customerId)
        {
            List<DonDatHangResponse> listResponse = new List<DonDatHangResponse>();
            List<DonDatHang> donDatHangs = _context.DonDatHang.Where(a => a.IdKhachHang == customerId).ToList();
            foreach (DonDatHang donDatHang in donDatHangs)
            {
               
                List<ChiTietDonDatHang> chiTietDonDatHangs = _context.ChiTietDonDatHang.Where(a => a.IdDonDatHang == donDatHang.IdDonDatHang).ToList();
                listResponse.Add(convert(donDatHang, chiTietDonDatHangs));
            }
            return listResponse;
        }
        private DonDatHangResponse convert(DonDatHang ddh,List<ChiTietDonDatHang> chiTietDonDatHangs)
        {
            DonDatHangResponse response = new DonDatHangResponse();
            List<ChiTietDatHangResponse> listResponse = new List<ChiTietDatHangResponse>();
            response.IdDonDatHang = ddh.IdDonDatHang;
            response.NgayTaoDonDatHang = ddh.NgayTaoDonDatHang;
            response.DiaChiNhanHang = ddh.DiaChiNhanHang;
            response.ThoiGianNhanHang = ddh.ThoiGianNhanHang;
            response.TrangThaiDonDatHang = ddh.TrangThaiDonDatHang;
            response.IdKhachHang = ddh.IdKhachHang;
            response.GhiChu = ddh.GhiChu;
            response.TongTien = ddh.TongTien;
            foreach(ChiTietDonDatHang ct in chiTietDonDatHangs)
            {
                listResponse.Add(converDetail(ct));
            }
            response.listChiTiet = listResponse;
            return response;   
        }

        private ChiTietDatHangResponse converDetail(ChiTietDonDatHang ctddh)
        {
            ChiTietDatHangResponse response = new ChiTietDatHangResponse();
            response.Id = ctddh.Id;
            response.IdHangHoa = ctddh.IdHangHoa;
            response.IdDonDatHang = ctddh.IdDonDatHang;
            response.SoLuongDatHang = ctddh.SoLuongDatHang;
            response.DonGiaDatHang = ctddh.DonGiaDatHang;
           
            return response;
    }
    }
}

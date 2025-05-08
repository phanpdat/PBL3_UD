using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        private readonly HoaDonDAL _hoaDonDAL = new HoaDonDAL();

       
         public void ThanhToan(int hocVienID, decimal tongTien, int soBuoiTap, int adminID, DateTime ngayDangKy)
        {
            
            var hoaDon = new HOADON
            {
                HocVienID = hocVienID,
                NgayLap = DateTime.Now, 
                TongTien = tongTien,
                AdminID = adminID,
                SoBuoiHoc = soBuoiTap,
                NgayDangKy =  ngayDangKy
            };

            _hoaDonDAL.CreateHoaDon(hoaDon);
        }

        public List<HoaDon_View> GetAllHoaDon()
        {
            try
            {
                var hoaDons = _hoaDonDAL.GetAllHoaDon();  

                var hoaDonViews = hoaDons.Select(hd => new HoaDon_View
                (
                    hd.HoaDonID,
                    hd.HOCVIEN.HoTen,  
                    hd.HOCVIEN.GOITAP.TenGoTap,
                    (hd.HOCVIEN.GOITAP.Gia ?? 0).ToString("N0"),
                    hd.SoBuoiHoc.GetValueOrDefault(),
                    (hd.TongTien ?? 0).ToString("N0")
                    
                )).ToList();

                return hoaDonViews;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
            }
        }

        public HOCVIEN GetHocVienByHoaDonID(int hoaDonID)
        {
            try
            {
                return _hoaDonDAL.GetHocVienByHoaDonID(hoaDonID);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi lấy thông tin học viên: " + ex.Message);
            }
        }

        public List<DoanhThuThang> GetDoanhThuTheoThang(int year)
        {
            var doanhThuTheoThang = _hoaDonDAL.GetAllHoaDon()
                .Where(hd => hd.NgayLap.HasValue && hd.NgayLap.Value.Year == year) // Lọc theo năm
                .GroupBy(hd => hd.NgayLap.Value.Month) // Nhóm theo tháng
                .Select(group => new DoanhThuThang
                {
                    Thang = group.Key,
                    DoanhThu = group.Sum(hd => hd.TongTien ?? 0)
                })
                .ToList();

            return doanhThuTheoThang;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocVienView

    {
        public int HocVienID { get; set; }  
        public string UserID { get; set; }  
        public string HoTen { get; set; }    
        public string SDT { get; set; }    
        public DateTime? NgaySinh { get; set; } 
        public String GioiTinh { get; set; }  
        public string GoiTapName { get; set; }  
        public string TrangThaiDangKy { get; set; }  
        public string TrangThaiThanhToan { get; set; }  

        public HocVienView() { }

        public HocVienView(int hocVienID, string userID, string hoTen, string sdt, DateTime? ngaySinh, String gioiTinh, string goiTapName, string trangThaiDangKy, string trangThaiThanhToan)
        {
            HocVienID = hocVienID;
            UserID = userID;
            HoTen = hoTen;
            SDT = sdt;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            GoiTapName = goiTapName;
            TrangThaiDangKy = trangThaiDangKy;
            TrangThaiThanhToan = trangThaiThanhToan;
        }
    } 
}


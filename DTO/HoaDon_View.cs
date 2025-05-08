using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon_View
    {
        public int hoaDonID { get; set; }
        public string TenHocVien { get; set; }
        public string TenGoiTap { get; set; }
        public string GiaGoiTap { get; set; }
        public string Gia1buoiTap { get; set; }
        public int SoBuoiTap { get; set; }
        public string ThanhTien { get; set; }


        public HoaDon_View(int hoaDonID, string tenHocVien, string tenGoiTap, string giaGoiTap, int soBuoiTap, string thanhTien, int? gia1buoiTap = 40000)
        {
            TenHocVien = tenHocVien;
            TenGoiTap = tenGoiTap;
            GiaGoiTap = giaGoiTap;
            SoBuoiTap = soBuoiTap;
            ThanhTien = thanhTien;
            Gia1buoiTap = gia1buoiTap?.ToString("N0");
            this.hoaDonID = hoaDonID;
        }

    }
}

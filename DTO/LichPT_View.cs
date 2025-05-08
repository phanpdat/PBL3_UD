using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichPT_View
    {
        public string HoTenPT { get; set; }
        public string ThuHoc { get; set; }
        public string BuoiHoc { get; set; }
        public int SoLuongHocVien { get; set; }
        public string GioHoc { get; set; }

        public LichPT_View(string hoTenPT, string thuHoc, string buoiHoc, int soLuongHocVien, string gioHoc)
        {
            HoTenPT = hoTenPT;
            ThuHoc = thuHoc;
            BuoiHoc = buoiHoc;
            SoLuongHocVien = soLuongHocVien;
            GioHoc = gioHoc;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichHocHV_View
    {
        public string HoTenHV { get; set; }
        public string HoTenPT { get; set; }
        public string ThuHoc { get; set; }
        public string BuoiHoc { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public String GioHoc { get; set; }
        //public int HocVienID { get; set; }
        //public int PTID { get; set; }
        public LichHocHV_View(string hoTenHV, string hoTenPT, string thuHoc, string buoiHoc, DateTime? ngayDangKy, string gioHoc)
        {
            HoTenHV = hoTenHV;
            HoTenPT = hoTenPT;
            ThuHoc = thuHoc;
            BuoiHoc = buoiHoc;
            NgayDangKy = ngayDangKy;
            GioHoc = gioHoc;
            //this.HocVienID = HocVienID;
            //this.PTID = PTID;
        }
    }
}

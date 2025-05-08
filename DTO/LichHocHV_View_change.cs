using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichHocHV_View_change
    {
        public int id { get; set; }
        public string HoTenHV { get; set; }
        public string HoTenPT { get; set; }
        public string ThuHoc { get; set; }
        public string BuoiHoc { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public int HocVienID { get; set; }
        public int PTID { get; set; }

        public LichHocHV_View_change(int id, string hoTenHV, string hoTenPT, string thuHoc, string buoiHoc, DateTime? ngayDangKy, int hocVienID, int ptID)
        {
            this.id = id;
            HoTenHV = hoTenHV;
            HoTenPT = hoTenPT;
            ThuHoc = thuHoc;
            BuoiHoc = buoiHoc;
            NgayDangKy = ngayDangKy;
            HocVienID = hocVienID;
            PTID = ptID;
        }
    }
}

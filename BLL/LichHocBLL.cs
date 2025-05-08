
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class LichHocBLL
    {
        private LichHocDAL lichHocDAL;
        private GYM2Entities context = new GYM2Entities();

        private string GetGioHoc(string buoiHoc)
        {
            switch (buoiHoc)
            {
                case "Sáng":
                    return "07:00";
                case "Chiều":
                    return "14:00";
                case "Tối":
                    return "19:00";
                default:
                    return "N/A";
            }
        }
        public LichHocBLL()
        {
            lichHocDAL = new LichHocDAL();
        }

        public List<LichHocHV_View> GetLichHocByHocVienID(int hocVienID)
        {
            String Giohoc;
            var lichHocs = lichHocDAL.GetLichHocByHocVienID(hocVienID);

            var lichHocViews = lichHocs.Select(lh => new LichHocHV_View(
                lh.HOCVIEN.HoTen,
                lh.PT.HoTen,
                lh.ThuHoc,
                lh.BuoiHoc,
                lh.NgayDangKy ?? DateTime.MinValue,
                Giohoc = GetGioHoc(lh.BuoiHoc)
        
            )).ToList();

            return lichHocViews;
        }

        public List<LichHocHV_View_change> GetLichHocByHocVienIDChange(int hocVienID)
        {
            var lichHocs = lichHocDAL.GetLichHocByHocVienID(hocVienID);

            var lichHocViews = lichHocs.Select(lh => new LichHocHV_View_change(
                lh.LichID,
                lh.HOCVIEN.HoTen,
                lh.PT.HoTen,
                lh.ThuHoc,
                lh.BuoiHoc,
                lh.NgayDangKy ?? DateTime.MinValue,
                lh.PT.PTID,
                lh.HOCVIEN.HocVienID

            )).ToList();

            return lichHocViews;
        }


        public void SaveLichHocToDatabase(List<LICH_HOC> lichHocList)
        {
            if (lichHocList != null && lichHocList.Count > 0)
            {
                lichHocDAL.SaveLichHoc(lichHocList);
            }
            else
            {
                throw new Exception("Danh sách lịch học rỗng.");
            }
        }
        public List<LichPT_View> GetLichPTByPTID(int ptID, string thuHoc)
        {
           
            var lichPTList = lichHocDAL.GetLichPTByPTID(ptID, thuHoc);

            var lichPTViews = lichPTList.Select(lh => new LichPT_View
            (
                lh.PT?.HoTen ?? string.Empty,  
                lh.ThuHoc,    
                lh.BuoiHoc,                                        
               context.LICH_HOC.Count(l => l.PTID == ptID && l.ThuHoc == thuHoc && l.BuoiHoc == lh.BuoiHoc),
                lh.BuoiHoc == "Sáng" ? "7h" : (lh.BuoiHoc == "Chiều" ? "14h" : "19h") 
            )).ToList();

            return lichPTViews;
        }

        public List<LichPT_View> GetAllLichPTByPTID(int ptID)
        {
            var lichPTList = lichHocDAL.GetAllLichPTByPTID(ptID);

            var lichPTViews = lichPTList
                .GroupBy(lh => new { lh.ThuHoc, lh.BuoiHoc })  
                .Select(g => new LichPT_View(
                    g.First().PT.HoTen, 
                    g.Key.ThuHoc,       
                    g.Key.BuoiHoc,      
                    g.Count(),         
                    g.Key.BuoiHoc == "Sáng" ? "7h" : (g.Key.BuoiHoc == "Chiều" ? "14h" : "19h")  
                )).OrderBy(lh => lh.ThuHoc)
                .ToList();

            return lichPTViews;
        }

        public List<HOCVIEN> GetHocVienByLichHoc(string hoTenPT, string thuHoc, string buoiHoc) => lichHocDAL.GetHocVienByLichHoc(hoTenPT, thuHoc, buoiHoc);


        public int GetSoBuoiTap(int hocVienID)=> lichHocDAL.GetSoBuoiTapByHocVien(hocVienID);

        public LICH_HOC GetLichHocById(int lichHocID)=>lichHocDAL.GetLichHocById(lichHocID);
    
        public void UpdateLichHoc(int lichHocID, string thuHoc, string buoiHoc, DateTime ngayDangKy, int ptID)=> lichHocDAL.UpdateLichHoc(lichHocID, thuHoc, buoiHoc, ngayDangKy, ptID);
    }
}

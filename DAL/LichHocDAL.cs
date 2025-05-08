
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LichHocDAL
    {
        private GYM2Entities context;

        public LichHocDAL()
        {
            context = new GYM2Entities();
        }

        public List<LICH_HOC> GetLichHocByHocVienID(int hocVienID)
        {
            var lichHocs = context.LICH_HOC
                .Where(lh => lh.HocVienID == hocVienID) 
                .ToList();

            return lichHocs;
        }


        public void SaveLichHoc(List<LICH_HOC> lichHocList)
        {
            foreach (var lichHocView in lichHocList)
            {
                var lichHocEntity = new LICH_HOC
                {
                    HocVienID = lichHocView.HocVienID,
                    PTID = lichHocView.PTID,
                    ThuHoc = lichHocView.ThuHoc,       
                    BuoiHoc = lichHocView.BuoiHoc,     
                    NgayDangKy = lichHocView.NgayDangKy 
                };

                context.LICH_HOC.Add(lichHocEntity);
            }            
            context.SaveChanges();
        }

        public List<LICH_HOC> GetLichPTByPTID(int ptID, string thuHoc)
        {
            var lichPTList = context.LICH_HOC
                .Where(lh => lh.PTID == ptID && lh.ThuHoc == thuHoc)  
                .ToList(); 

            return lichPTList;
        }

        public List<LICH_HOC> GetAllLichPTByPTID(int ptID)
        {
            var lichPTList = context.LICH_HOC
                .Where(lh => lh.PTID == ptID) 
                .ToList(); 

            return lichPTList;
        }

        public List<HOCVIEN> GetHocVienByLichHoc(string hoTenPT, string thuHoc, string buoiHoc)
        {
            var hocVienList = (from lh in context.LICH_HOC
                               join hv in context.HOCVIENs on lh.HocVienID equals hv.HocVienID
                               where lh.PT.HoTen == hoTenPT && lh.ThuHoc == thuHoc && lh.BuoiHoc == buoiHoc
                               select hv).ToList();

            return hocVienList;
        }
        public int GetSoBuoiTapByHocVien(int hocVienID)
        {
            var soBuoiTap = context.LICH_HOC.Count(lh => lh.HocVienID == hocVienID);

            return soBuoiTap;
        }

        public LICH_HOC GetLichHocById(int lichHocID)
        {
           
            var lichHoc = context.LICH_HOC
                .Where(lh => lh.LichID == lichHocID)
                .FirstOrDefault(); 

            return lichHoc;
        }

        public void UpdateLichHoc(int lichHocID, string thuHoc, string buoiHoc, DateTime ngayDangKy, int ptID)
        {
            var lichHoc = context.LICH_HOC.FirstOrDefault(lh => lh.LichID == lichHocID);

            if (lichHoc != null)
            {
                lichHoc.ThuHoc = thuHoc;
                lichHoc.BuoiHoc = buoiHoc;
                lichHoc.NgayDangKy = ngayDangKy;
                lichHoc.PTID = ptID;

                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}



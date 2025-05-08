
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HocVienDAL
    {
        private GYM2Entities context = new GYM2Entities();

        public void UpdateHocVien(HOCVIEN hocVien)
        {
            var existingHocVien = context.HOCVIENs.FirstOrDefault(hv => hv.UserID == hocVien.UserID);
            if (existingHocVien != null)
            {
                existingHocVien.HoTen = hocVien.HoTen;
                existingHocVien.SDT = hocVien.SDT;
                existingHocVien.NgaySinh = hocVien.NgaySinh;
                existingHocVien.Gender = hocVien.Gender;
                existingHocVien.IsRegistered = hocVien.IsRegistered;
                existingHocVien.IsPaid = hocVien.IsPaid;

                context.SaveChanges();
            } 
        }

        public void InsertHocVien(HOCVIEN hocVien)
        {
            context.HOCVIENs.Add(hocVien);  
            context.SaveChanges();  
        }

        public HOCVIEN GetHocVienByUserID(string userID)
        {
            return context.HOCVIENs.FirstOrDefault(hv => hv.UserID == userID);
        }

        public List<HOCVIEN> GetHocVienList()
        {
            return context.HOCVIENs.ToList();
        }

        public void DeleteHocVienAndAccount(string userID)
        {
            var hocVien = context.HOCVIENs.FirstOrDefault(hv => hv.UserID == userID);

            if (hocVien != null)
            {
                var lichHoc = context.LICH_HOC.Where(lh => lh.HocVienID == hocVien.HocVienID);
                context.LICH_HOC.RemoveRange(lichHoc);
                context.HOCVIENs.Remove(hocVien);

                var user = context.USERS.FirstOrDefault(u => u.UserID == userID);
                if (user != null)
                {
                    context.USERS.Remove(user);
                }

                context.SaveChanges();
            }
        }

        public List<HOCVIEN> GetHocVienByPaymentStatus(bool isPaid)
        {
            return context.HOCVIENs.Where(hv => hv.IsPaid == isPaid).ToList();
        }

        public HOCVIEN GetHocVienByID(int hocVienID)
        {
            return context.HOCVIENs.FirstOrDefault(hv => hv.HocVienID == hocVienID);
        }

        public void UpdateHV(HOCVIEN hocVien)
        {
            var existingHocVien = context.HOCVIENs.FirstOrDefault(h => h.HocVienID == hocVien.HocVienID);
            if (existingHocVien != null)
            {
                existingHocVien.UserID = hocVien.UserID;
                existingHocVien.HoTen = hocVien.HoTen;
                existingHocVien.SDT = hocVien.SDT;
                existingHocVien.NgaySinh = hocVien.NgaySinh;
                existingHocVien.Gender = hocVien.Gender;

                context.SaveChanges();
            }
        }

        public void UpdateRegisterHocVien(HOCVIEN hocVien)
        {
            context.Entry(hocVien).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges(); 
        }
        public GOITAP GetGoiTapByID(int goTapID)
        {
            return context.GOITAPs.FirstOrDefault(gt => gt.GoTapID == goTapID); 
        }

        public USER GetUserByHocVienID(int hocVienID)
        {
            var hocVien = context.HOCVIENs.FirstOrDefault(hv => hv.HocVienID == hocVienID);
            if (hocVien != null)
            {
                return context.USERS.FirstOrDefault(u => u.UserID == hocVien.UserID);
            }
            return null; 
        }

        public void UpdateHocVienStatus(HOCVIEN hocVien)
        {
            var existingHocVien = context.HOCVIENs.FirstOrDefault(hv => hv.HocVienID == hocVien.HocVienID);
            if (existingHocVien != null)
            {
                existingHocVien.IsRegistered = hocVien.IsRegistered;  

                context.SaveChanges(); 
            }
        }

        public void UpdateIsPaid(int hocVienID)
        {
            var hocVien = context.HOCVIENs.FirstOrDefault(hv => hv.HocVienID == hocVienID);
            if (hocVien != null)
            {
                hocVien.IsPaid = true; 
                context.SaveChanges(); 
            }
        }

    }
}

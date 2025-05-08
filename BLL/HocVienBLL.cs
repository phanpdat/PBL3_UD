using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace BLL
{
    public class HocVienBLL
    {
        private readonly HocVienDAL _hocVienDAL = new HocVienDAL();
        private readonly GoiTapDAL dal = new GoiTapDAL();

        public void UpdateHocVien(HOCVIEN hocVien)=> _hocVienDAL.UpdateHV(hocVien);

        public void AddHocVien(HOCVIEN hocVien) => _hocVienDAL.InsertHocVien(hocVien);

        public HOCVIEN GetHocVienByUserID(string userID) => _hocVienDAL.GetHocVienByUserID(userID);

        public List<HocVienView> GetHocVienList() { 
            var hocViens= _hocVienDAL.GetHocVienList();
            var goiTaps = dal.GetAll();
            var hocVienList = hocViens.Select(hv => new HocVienView
            {
                HocVienID = hv.HocVienID,
                UserID = hv.UserID,
                HoTen = hv.HoTen,
                SDT = hv.SDT,
                NgaySinh = hv.NgaySinh,
                GioiTinh = hv.Gender.GetValueOrDefault() ? "nam" : "nu",
                GoiTapName = goiTaps.FirstOrDefault(gt => gt.GoTapID == hv.GoTapID)?.TenGoTap ?? "Chưa đăng ký",
                TrangThaiDangKy = hv.IsRegistered.GetValueOrDefault() ? "Đã đăng ký" : "Chưa",
                TrangThaiThanhToan = hv.IsPaid.GetValueOrDefault() ? "Đã thanh toán" : "Chưa"
            }).ToList();

            return hocVienList;
        }


        public void DeleteHocVienAndAccount(string userID) => _hocVienDAL.DeleteHocVienAndAccount(userID);

        public List<HocVienView> GetHocVienByPaymentStatus(bool isPaid) { 
            var hocViens = _hocVienDAL.GetHocVienByPaymentStatus(isPaid);
            var goiTaps = dal.GetAll();
            var hocVienPaymentStatus = hocViens.Select(hv => new HocVienView
            {
                HocVienID = hv.HocVienID,
                UserID = hv.UserID,
                HoTen = hv.HoTen,
                SDT = hv.SDT,
                NgaySinh = hv.NgaySinh,
                GioiTinh = hv.Gender.GetValueOrDefault() ? "nam" : "nu",
                GoiTapName = goiTaps.FirstOrDefault(gt => gt.GoTapID == hv.GoTapID)?.TenGoTap ?? "Chưa đăng ký",
                TrangThaiDangKy = hv.IsRegistered.GetValueOrDefault() ? "Đã đăng ký" : "Chưa",
                TrangThaiThanhToan = hv.IsPaid.GetValueOrDefault() ? "Đã thanh toán" : "Chưa"
            }).ToList();

            return hocVienPaymentStatus;
        }

        public HOCVIEN GetHocVienByID(int hocVienID) => _hocVienDAL.GetHocVienByID(hocVienID);

        public void RegisterGoiTap(int hocVienID, int goTapID, DateTime ngayDangKy, DateTime ngayHetHan)
        {
            var hocVien = _hocVienDAL.GetHocVienByID(hocVienID);  
            if (hocVien != null)
            {
                hocVien.GoTapID = goTapID;
                hocVien.NgayBatDau = ngayDangKy;
                hocVien.NgayHetHan = ngayHetHan;
                 _hocVienDAL.UpdateRegisterHocVien(hocVien);  
            }
            else
            {
                throw new Exception("Học viên không tồn tại.");
            }
        }

        public GOITAP GetGoiTapByID(int goTapID)=> _hocVienDAL.GetGoiTapByID(goTapID);

        public USER GetUserByHocVienID(int hocVienID)=> _hocVienDAL.GetUserByHocVienID(hocVienID);

        public void UpdateHocVienStatus(HOCVIEN hocVien)=> _hocVienDAL.UpdateHocVienStatus(hocVien);

        public void UpdateIsPaid(int hocVienID)=> _hocVienDAL.UpdateIsPaid(hocVienID);
        
    }
}

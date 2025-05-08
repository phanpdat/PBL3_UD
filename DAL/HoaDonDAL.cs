
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        GYM2Entities context=new GYM2Entities();
        public void CreateHoaDon(HOADON hoaDon)
        {
            context.HOADONs.Add(hoaDon);
            context.SaveChanges(); 
        }
        public List<HOADON> GetAllHoaDon()
        {
            try
            {
                return context.HOADONs.ToList();  
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả hóa đơn: " + ex.Message);
            }
        }

        public HOCVIEN GetHocVienByHoaDonID(int hoaDonID)
        {
            try
            {
                var hoaDon = context.HOADONs
                    .Where(hd => hd.HoaDonID == hoaDonID)  
                    .Select(hd => hd.HOCVIEN)  
                    .FirstOrDefault();  

                return hoaDon;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi truy vấn học viên: " + ex.Message);
            }
        }
    }
}

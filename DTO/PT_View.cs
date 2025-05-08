using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PT_View
    {
        public int PTID { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public DateTime? NgaySinh { get; set; }
        public String Gender { get; set; }
        public string UserID { get; set; }

        public PT_View(int ptID, string hoTen, string sdt, DateTime? ngaySinh, String gender, string userID)
        {
            PTID = ptID;
            HoTen = hoTen;
            SDT = sdt;
            NgaySinh = ngaySinh;
            Gender =gender;  
            UserID = userID;
        }
    }
}

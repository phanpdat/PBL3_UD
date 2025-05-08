using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GoiTap_View
    {
        public int GoiTapID { get; set; }
        public string GoiTapName { get; set; }
        public string Gia { get; set; }
        public string ThoiLuong { get; set; }   

        public GoiTap_View(int GoiTapID,string GoiTapName,string Gia,string ThoiLuong) 
        {
            this.GoiTapID = GoiTapID;
            this.GoiTapName = GoiTapName;
            this.Gia = Gia;
            this.ThoiLuong = ThoiLuong;
        }
    } 
}

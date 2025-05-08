using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace DTO
{
    public class Cbb_Item_GT
    {
        public int GoTapID { get; set; }   
        public string TenGt { get; set; }
        public decimal? Gia { get; set; }
        public int? ThoiGian { get; set; }

        public Cbb_Item_GT(int goTapID, string text, decimal? value, int? thoiGian)
        {
            GoTapID = goTapID;
            TenGt = text;
            Gia = value;
            ThoiGian = thoiGian;
        }

        public override string ToString()
        {
            return TenGt; 
        }
    }
}

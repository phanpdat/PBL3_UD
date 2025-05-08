using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class GoiTapBLL
    {
        private  GoiTapDAL dal = new GoiTapDAL();

        private string FormatGia(decimal? gia)
        {
            if (gia.HasValue)
            {
                return gia.Value.ToString("N0") + " VND";
            }
            else
            {
                return "Chưa có giá";
            }
        }

          public List<GoiTap_View> GetAll() {
           var GT= dal.GetAll();
           var GTList = GT.Select(gt => new GoiTap_View
           (
                gt.GoTapID,
                gt.TenGoTap,
                FormatGia(gt.Gia),
                gt.ThoiLuong + " tháng"
           )).ToList();
            return GTList;

        }

        public void Add(GOITAP gt) => dal.Insert(gt);

        public void Delete(int id) => dal.Delete(id);

        public void Update(GOITAP gt) => dal.Update(gt);

        public List<Cbb_Item_GT> GetAllGoiTapForComboBox()
        {
            var goiTaps = dal.GetAll (); 
            List<Cbb_Item_GT> cbbItems = new List<Cbb_Item_GT>();

            foreach (var gt in goiTaps)
            {
                cbbItems.Add(new Cbb_Item_GT(gt.GoTapID, gt.TenGoTap, gt.Gia, gt.ThoiLuong));
            }

            return cbbItems;
        }
    }
}

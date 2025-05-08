using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GoiTapDAL
    {
        private GYM2Entities context = new GYM2Entities();

        public List<GOITAP> GetAll()
        {
            return context.GOITAPs.ToList();
        }



        public GOITAP GetLastGoiTap()
        {
            return context.GOITAPs.OrderByDescending(gt => gt.GoTapID).FirstOrDefault();

        }

        public void Insert(GOITAP gt)
        {
            context.GOITAPs.Add(gt);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var goiTap = context.GOITAPs.FirstOrDefault(g => g.GoTapID == id); 
            if (goiTap != null)
            {
                context.GOITAPs.Remove(goiTap);
                context.SaveChanges();
            }
        }
        public void Update(GOITAP gt)
        {
            context.GOITAPs.AddOrUpdate(g => g.GoTapID, gt);
            context.SaveChanges();
        }
    }
}

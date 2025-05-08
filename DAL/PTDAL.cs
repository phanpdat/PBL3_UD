
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PTDAL
    {
        private GYM2Entities context;

        public PTDAL()
        {
            context = new GYM2Entities();
        }

        public void AddPT(PT pt)
        {
            context.PTs.Add(pt);
            context.SaveChanges();  
        }

        public List<PT> GetAll()=> context.PTs.ToList();

        public void DeletePTAndAccount(string userID)
        {
            var pt = context.PTs.FirstOrDefault(p => p.UserID == userID);

            if (pt != null)
            {
                var lichHoc = context.LICH_HOC.Where(lh => lh.PTID == pt.PTID);
                context.LICH_HOC.RemoveRange(lichHoc);

                context.PTs.Remove(pt);

                var user = context.USERS.FirstOrDefault(u => u.UserID == userID);
                if (user != null)
                {                 
                    context.USERS.Remove(user);
                }

                context.SaveChanges();
            }
        }

        public PT GetPTByUserID(string userID)=> context.PTs.FirstOrDefault(pt => pt.UserID == userID);

        public void UpdatePT(PT pt)
        {
            var existingPT = context.PTs.FirstOrDefault(p => p.PTID == pt.PTID);
            if (existingPT != null)
            {
                existingPT.UserID = pt.UserID;  
                existingPT.HoTen = pt.HoTen;
                existingPT.SDT = pt.SDT;
                existingPT.NgaySinh = pt.NgaySinh;
                existingPT.Gender = pt.Gender;

                context.SaveChanges();
            }
        }
        public PT GetPTByID(int ptID)=>context.PTs.FirstOrDefault(pt => pt.PTID == ptID);
      

        public USER GetUserByPTID(int ptID)
        {
            var pt = context.PTs.FirstOrDefault(p => p.PTID == ptID);
            if (pt != null)
            { 
                return context.USERS.FirstOrDefault(u => u.UserID == pt.UserID);
            }
            return null; 
        }
    }
}

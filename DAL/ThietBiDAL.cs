
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
      public class ThietBiDAL
    {
        private readonly GYM2Entities _context;

        public ThietBiDAL()
        {
            _context = new GYM2Entities();
        }

        public List<THIETBI> GetAll() => _context.THIETBIs.ToList();

        public void Insert(THIETBI thietBi)
        {
            _context.THIETBIs.Add(thietBi);
            _context.SaveChanges();
        }

        public void Update(THIETBI thietBi)
        {
            var existingThietBi = _context.THIETBIs.FirstOrDefault(t => t.ThietBiID == thietBi.ThietBiID);
            if (existingThietBi != null)
            {
                existingThietBi.TenThietBi = thietBi.TenThietBi;
                existingThietBi.SoLuong = thietBi.SoLuong;
                existingThietBi.SoLuongTot = thietBi.SoLuongTot;
                existingThietBi.SoLuongHong = thietBi.SoLuongHong;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var thietBi = _context.THIETBIs.FirstOrDefault(t => t.ThietBiID == id);
            if (thietBi != null)
            {
                _context.THIETBIs.Remove(thietBi);
                _context.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            var allThietBis = _context.THIETBIs.ToList();
            _context.THIETBIs.RemoveRange(allThietBis);
            _context.SaveChanges();
        }

        public List<THIETBI> GetBySoLuong(int soLuong) => _context.THIETBIs.Where(t => t.SoLuong == soLuong).ToList();
        public THIETBI getTBbyID(int ID) => _context.THIETBIs.FirstOrDefault(t => t.ThietBiID == ID);

    }
}


using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     public class ThietBiBLL
    {
        private readonly ThietBiDAL _dal;

        public ThietBiBLL()
        {
            _dal = new ThietBiDAL();
        }

        public List<THIETBI> GetAll() => _dal.GetAll();

        public void Add(THIETBI thietBi) => _dal.Insert(thietBi);

        public void Update(THIETBI thietBi) => _dal.Update(thietBi);

        public void Delete(int id) => _dal.Delete(id);

        public void DeleteAll() => _dal.DeleteAll();

        public List<THIETBI> GetBySoLuong(int soLuong) => _dal.GetBySoLuong(soLuong);

        public THIETBI getTBbyID(int ID)=>_dal.getTBbyID(ID);
    }
}


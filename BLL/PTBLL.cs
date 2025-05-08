
using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PTBLL
    {
        private readonly PTDAL _ptDAL = new PTDAL();

        public void AddPT(PT pt) => _ptDAL.AddPT(pt);

        public List<PT_View> GetAllPT()
        {
            var ptList = _ptDAL.GetAll();  
            var ptViewList = ptList.Select(pt => new PT_View(
                pt.PTID,
                pt.HoTen,
                pt.SDT,
                pt.NgaySinh,
                pt.Gender.GetValueOrDefault()?"Nam":"Nữ",
                pt.UserID
            )).ToList();

            return ptViewList;  
        }

        public void UpdatePT(PT pt)=> _ptDAL.UpdatePT(pt);

        public void DeletePTAndAccount(string userID) => _ptDAL.DeletePTAndAccount(userID);

        public PT GetPTByUserID(string userID) => _ptDAL.GetPTByUserID(userID);

        public PT GetPTByID(int ptID) => _ptDAL.GetPTByID(ptID);

        public USER GetUserByPTID(int ptID)=> _ptDAL.GetUserByPTID(ptID);
    }
}

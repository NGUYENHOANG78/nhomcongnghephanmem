using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhomSanPhamDAO
    {
        private static NhomSanPhamDAO instance;
        public static NhomSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhomSanPhamDAO();
                return instance;
            }
        }
        public List<nhomsanpham> getNhomSP()
        {
            List<nhomsanpham> dsNhom = new List<nhomsanpham>();

            dsNhom = DataProvider.Ins.DB.nhomsanphams.ToList();

            return dsNhom;
        }
        public bool suaNhomSP(nhomsanpham nsp)
        {
            nhomsanpham temp = findNhomSP(nsp.id_nhom);
            if (temp != null)
            {
                temp.tennhom = nsp.tennhom;
                temp.ngaytao = nsp.ngaytao;
                temp.ngaycapnhat = DateTime.Now;
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool themNhomSP(nhomsanpham nsp)
        {

            nhomsanpham a = findNhomSP(nsp.id_nhom);
            if (a == null)
            {
                DataProvider.Ins.DB.nhomsanphams.Add(nsp);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool xoaNhomSP(string id)
        {
            nhomsanpham a = findNhomSP(id);
            if (a != null && a.loaisanphams.Count == 0 && a.thuonghieux.Count == 0 )
            {
                DataProvider.Ins.DB.nhomsanphams.Remove(a);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;                    
        }
        public nhomsanpham findNhomSP(string id)
        {
            nhomsanpham a = null;
            a = DataProvider.Ins.DB.nhomsanphams.Find(id);
            if (a != null)
                return a;
            return null;
        }
    }
}

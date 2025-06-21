using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhapKhoDAO
    {
        private static NhapKhoDAO instance;
        public static NhapKhoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhapKhoDAO();
                return instance;
            }
        }
        public List<phieunhap> GetPhieunhaps()
        {
            List<phieunhap> dsPhieuNhap = new List<phieunhap>();

            dsPhieuNhap = DataProvider.Ins.DB.phieunhaps.ToList();

            return dsPhieuNhap;
        }
        public bool themPhieuNhap(phieunhap pn)
        {
            phieunhap a = findPhieuNhap(pn.id_phieunhap);
            if (a == null)
            {
                DataProvider.Ins.DB.phieunhaps.Add(pn);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public phieunhap findPhieuNhap(int id)
        {
            phieunhap a = null;
            a = DataProvider.Ins.DB.phieunhaps.Find(id);
            if (a != null)
                return a;
            return null;
        }
    }
}

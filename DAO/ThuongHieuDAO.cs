using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThuongHieuDAO
    {
        private static ThuongHieuDAO instance;
        public static ThuongHieuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThuongHieuDAO();
                return instance;
            }
        }
        public List<thuonghieu> getListThuongHieu()
        {
            List<thuonghieu> dsThuongHieu = new List<thuonghieu>();

            dsThuongHieu = DataProvider.Ins.DB.thuonghieux.ToList();
            return dsThuongHieu;
        }
        public bool suaThuongHieu(thuonghieu th)
        {
            thuonghieu temp = findThuongHieu(th.id_thuonghieu);
            if (temp != null)
            {
                temp.id_nhom = th.id_nhom;
                temp.ngaytao = th.ngaytao;
                temp.tenthuonghieu = th.tenthuonghieu;
                temp.ngaycapnhat = DateTime.Now;
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool themThuongHieu(thuonghieu th)
        {
            thuonghieu a = findThuongHieu(th.id_thuonghieu);
            if (a == null)
            {
                DataProvider.Ins.DB.thuonghieux.Add(th);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool xoaThuongHieu(int id)
        {
            thuonghieu a = findThuongHieu(id);
            if (a != null && a.sanphams.Count == 0)
            {
                DataProvider.Ins.DB.thuonghieux.Remove(a);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;        
        }
        public thuonghieu findThuongHieu(int id)
        {
            thuonghieu a = null;
            a = DataProvider.Ins.DB.thuonghieux.Find(id);
            if (a != null)
                return a;
            return null;
        }
    }
}

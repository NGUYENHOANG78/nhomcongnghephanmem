using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThanhToanDAO
    {
        private static ThanhToanDAO instance;
        public static ThanhToanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThanhToanDAO();
                return instance;
            }
        }
        public List<phuongthucthanhtoan> getListThanhToan()
        {
            List<phuongthucthanhtoan> dsThanhToan = new List<phuongthucthanhtoan>();

            dsThanhToan = DataProvider.Ins.DB.phuongthucthanhtoans.ToList();

            return dsThanhToan;
        }
        public bool suaThanhToan(phuongthucthanhtoan pt)
        {
            phuongthucthanhtoan temp = findThanhToan(pt.id_thanhtoan);
            if (temp != null)
            {
                temp.tenthanhtoan = pt.tenthanhtoan;              
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool themThanhToan(phuongthucthanhtoan pt)
        {
            phuongthucthanhtoan a = findThanhToan(pt.id_thanhtoan);
            if (a == null)
            {
                DataProvider.Ins.DB.phuongthucthanhtoans.Add(pt);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }

        public bool xoaThanhToan(int id)
        {
            phuongthucthanhtoan a = findThanhToan(id);
            if (a != null && a.donhangs.Count == 0)
            {
                DataProvider.Ins.DB.phuongthucthanhtoans.Remove(a);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;          
        }
        public phuongthucthanhtoan findThanhToan(int id)
        {
            phuongthucthanhtoan a = null;
            a = DataProvider.Ins.DB.phuongthucthanhtoans.Find(id);
            if (a != null)
                return a;
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return instance;
            }
        }
        public List<khachhang> GetKhachhangs()
        {
            List<khachhang> khachhangs = new List<khachhang>();

            khachhangs = DataProvider.Ins.DB.khachhangs.OrderByDescending(x => x.id_khachhang).ToList();
            return khachhangs;
        }
        public bool suaKhachHang(khachhang kh)
        {
            khachhang temp = findKhachHang(kh.id_khachhang);
            if (temp != null)
            {
                temp.matkhau = kh.matkhau;
                temp.ngaycapnhat = DateTime.Now;
                temp.ngaytao = kh.ngaytao;
                temp.ten = kh.ten;
                temp.diachi = kh.diachi;
                temp.email = kh.email;
                temp.sodienthoai = kh.sodienthoai;
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool themKhachHang(khachhang kh)
        {
            khachhang a = findKhachHangbySDT(kh.sodienthoai);
            if (a == null)
            {
                DataProvider.Ins.DB.khachhangs.Add(kh);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }    
        public khachhang findKhachHang(int id)
        {
            khachhang a = null;
            a = DataProvider.Ins.DB.khachhangs.Find(id);
            if (a != null)
                return a;
            return null;
        }
        public khachhang findKhachHangbySDT(string sdt)
        {
            khachhang a = null;
            foreach(var kh in GetKhachhangs().Where(p=>p.sodienthoai == sdt))
            {
                a = kh;
                break;
            }
            return a;
        }
    }
}

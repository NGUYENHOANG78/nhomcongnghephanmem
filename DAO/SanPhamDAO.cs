using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;
        public static SanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanPhamDAO();
                return instance;
            }
        }
        public List<sanpham> getListSanPham()
        {
            List<sanpham> dsSP = new List<sanpham>();

            dsSP = DataProvider.Ins.DB.sanphams.ToList();
            return dsSP;
        }
        public bool suaSanPham(sanpham sp)
        {
            sanpham temp = findSanPham(sp.id_sanpham);
            if (temp != null)
            {
                temp.id_thuonghieu = sp.id_thuonghieu;
                temp.khuyenmai = sp.khuyenmai;
                temp.loaisanpham = sp.loaisanpham;
                temp.mota = sp.mota;
                temp.ngaytao = sp.ngaytao;
                temp.tensanpham = sp.tensanpham;
                temp.hinh = sp.hinh;
                temp.thuonghieu = sp.thuonghieu;
                temp.baohanh = sp.baohanh;
                temp.gia = sp.gia;
                temp.id_loai = sp.id_loai;
                temp.ngaycapnhat = DateTime.Now;
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool themSanPham(sanpham sp)
        {
            sanpham a = findSanPham(sp.id_sanpham);
            if (a == null)
            {
                DataProvider.Ins.DB.sanphams.Add(sp);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool xoaSanPham(string id)
        {
            sanpham a = findSanPham(id);
            if (a != null && a.phieuxuats.Count == 0 && a.phieunhaps.Count == 0 && a.giohangs.Count == 0)
            {
                DataProvider.Ins.DB.sanphams.Remove(a);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;          
        }
        public sanpham findSanPham(string id)
        {
            sanpham a = null;
            a = DataProvider.Ins.DB.sanphams.Find(id);
            if (a != null)
                return a;
            return null;
        }
      

    }
}

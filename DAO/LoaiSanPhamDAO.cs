using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LoaiSanPhamDAO
    {
        private static LoaiSanPhamDAO instance;
        public static LoaiSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiSanPhamDAO();
                return instance;
            }
        }
        public List<loaisanpham> getLoaiSP()
        {
            List<loaisanpham> dsLoai = new List<loaisanpham>();

            dsLoai = DataProvider.Ins.DB.loaisanphams.ToList();
            return dsLoai;
        }
        public bool suaLoaiSP(loaisanpham lsp)
        {
            loaisanpham temp = findLoaiSP(lsp.id_loai);
            if (temp != null)
            {
                temp.tenloai = lsp.tenloai;
                temp.ngaytao = lsp.ngaytao;
                temp.id_nhom = lsp.id_nhom;
                temp.ngaycapnhat = DateTime.Now;
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool themLoaiSP(loaisanpham lsp)
        {
            loaisanpham a = findLoaiSP(lsp.id_loai);
            if (a == null)
            {
                DataProvider.Ins.DB.loaisanphams.Add(lsp);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool xoaLoaiSP(string id)
        {
            loaisanpham a = findLoaiSP(id);
            if (a != null && a.sanphams.Count == 0)
            {
                DataProvider.Ins.DB.loaisanphams.Remove(a);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;                             
        }
        public loaisanpham findLoaiSP(string id)
        {
            loaisanpham a = null;
            a = DataProvider.Ins.DB.loaisanphams.Find(id);
            if (a != null)
                return a;
            return null;
        }
    }
}

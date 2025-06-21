using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace BUS
{
    public class NhomSanPhamBUS
    {
        private static NhomSanPhamBUS instance;

        public static NhomSanPhamBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhomSanPhamBUS();
                return instance;
            }
        }
        public void showNhomSP(DataGridView data)
        {
            var result = from a in DAO.NhomSanPhamDAO.Instance.getNhomSP() select new { id_nhom = a.id_nhom, tennhom = a.tennhom, ngaytao = a.ngaytao, ngaycapnhat = a.ngaycapnhat};
            data.DataSource = result.ToList();
        }
        public bool suaNhomSP(string id, string name, DateTime ngaytao)
        {
            nhomsanpham a = new nhomsanpham();
            a.id_nhom = id;
            a.tennhom = name;
            a.ngaytao = ngaytao;
            a.ngaycapnhat = DateTime.Now;
            return NhomSanPhamDAO.Instance.suaNhomSP(a);
        }
        public bool themNhomSp(string id, string name)
        {
            nhomsanpham a = new nhomsanpham();
            a.id_nhom = id;
            a.tennhom = name;
            a.ngaytao = DateTime.Now;
            a.ngaycapnhat = DateTime.Now;
            return NhomSanPhamDAO.Instance.themNhomSP(a);
        }
        public bool xoaNhomSP(string id)
        {
            return NhomSanPhamDAO.Instance.xoaNhomSP(id);        
        }
        public void showTenNhomToCBO(string id,ComboBox cbo)
        {
            nhomsanpham a = NhomSanPhamDAO.Instance.findNhomSP(id);
            if (a!= null)
            {
                cbo.Text = a.tennhom;
            }
        }
        public void showListNhomSP(ComboBox cbo)
        {
            cbo.DataSource = DAO.NhomSanPhamDAO.Instance.getNhomSP();
            cbo.DisplayMember = "tennhom";
        }      
    }
}

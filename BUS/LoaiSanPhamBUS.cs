using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace BUS
{
    public class LoaiSanPhamBUS
    {
        private static LoaiSanPhamBUS instance;

        public static LoaiSanPhamBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiSanPhamBUS();
                return instance;
            }
        }
        public void showLoaiSP(DataGridView data)
        {
            var result = from a in DAO.LoaiSanPhamDAO.Instance.getLoaiSP() select new { id_loai = a.id_loai, tenloai = a.tenloai, id_nhom = a.nhomsanpham.id_nhom, ngaytao = a.ngaytao, ngaycapnhat = a.ngaycapnhat};
            data.DataSource = result.ToList();
        }
        public void showListLoaiSP(DataGridView data, ComboBox cboNhomSP)
        {
            List<loaisanpham> list = new List<loaisanpham>();
            nhomsanpham snp = cboNhomSP.SelectedItem as nhomsanpham;
            if(snp != null)
            {
                foreach (loaisanpham a in LoaiSanPhamDAO.Instance.getLoaiSP().Where(x => x.id_nhom == snp.id_nhom))
                {
                    list.Add(a);
                }
                data.DataSource = list;
            }
        }
        public bool suaLoaiSP(string id,ComboBox cboNhomSP, string name, DateTime ngaytao)
        {
            loaisanpham a = new loaisanpham();
            nhomsanpham nsp = cboNhomSP.SelectedItem as nhomsanpham;
            if (nsp != null)
            {
                a.id_loai = id;
                a.nhomsanpham = nsp;
                a.id_nhom = nsp.id_nhom;
                a.ngaytao = ngaytao;
                a.tenloai = name;
            }
            a.ngaycapnhat = DateTime.Now;
            return LoaiSanPhamDAO.Instance.suaLoaiSP(a);
        }
        private string taoMaTuDong()
        {
            Random r = new Random();
            string id = "L";
            int l = 5 - id.Length;
            for (int i = 0; i < l; i++)
            {
                id = id + r.Next(0, 9);
            }
            return id;
        }
        public bool themLoaiSP(ComboBox cboNhomSP, string tenloai)
        {
            loaisanpham a = new loaisanpham();
            nhomsanpham nsp = cboNhomSP.SelectedItem as nhomsanpham;
            if (nsp != null)
            {
                a.nhomsanpham = nsp;
                a.id_nhom = nsp.id_nhom;
                a.tenloai = tenloai;
                a.id_loai = taoMaTuDong();
                a.ngaytao = DateTime.Now;
                a.ngaycapnhat = DateTime.Now;
            }
            return LoaiSanPhamDAO.Instance.themLoaiSP(a);
        }
        public bool xoaLoaiSP(string id)
        {
            return LoaiSanPhamDAO.Instance.xoaLoaiSP(id);         
        }
    }
}

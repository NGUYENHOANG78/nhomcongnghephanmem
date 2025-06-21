using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BUS
{
    public class NhapKhoBUS
    {
        private static NhapKhoBUS instance;

        public static NhapKhoBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhapKhoBUS();
                return instance;
            }
        }
        public void showPhieuNhap(DataGridView data)
        {
            var result = from a in DAO.NhapKhoDAO.Instance.GetPhieunhaps() select new { id = a.id_phieunhap, id_sanpham = a.id_sanpham, soluong = a.soluongsp, gianhap = a.gianhap, ngaynhap = a.ngaynhap};
            data.DataSource = result.ToList();
        }     
        public void showLinhKienToComboBox(ComboBox cbo)
        {
            List<DAO.sanpham> dsSanPham = DAO.SanPhamDAO.Instance.getListSanPham();
            cbo.DataSource = dsSanPham;
        }
        public bool themPhieuNhap(string id_sanpham,int soluong, decimal gianhap)
        {
            DAO.phieunhap a = new DAO.phieunhap();
            a.id_sanpham = id_sanpham;
            a.soluongsp = soluong;
            a.gianhap = gianhap;
            a.ngaynhap = DateTime.Now;
            return DAO.NhapKhoDAO.Instance.themPhieuNhap(a);
        }     
        public void selectChangesFromCboMaLk(ComboBox cboIDLK, ComboBox cboTenLK)
        {
            DAO.sanpham a = DAO.SanPhamDAO.Instance.findSanPham(cboIDLK.Text);
            if (a != null)
            {
                cboTenLK.Text = a.tensanpham;
            }
        }
        public void selectChangesFromCboTenLK(ComboBox cboIDLK, ComboBox cboTenLK)
        {
            DAO.sanpham a = cboTenLK.SelectedItem as DAO.sanpham;
            if (a != null)
            {
                cboIDLK.Text = a.id_sanpham;
            }
        }
    }
}

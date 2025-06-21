using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;

        public static KhachHangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangBUS();
                return instance;
            }
        }
        public void showKhachHang(DataGridView data)
        {
            var result = from a in DAO.KhachHangDAO.Instance.GetKhachhangs() select new { id = a.id_khachhang, ten = a.ten, email = a.email, matkhau = a.matkhau, sodienthoai = a.sodienthoai, diachi = a.diachi,ngaytao = a.ngaytao, ngaycapnhat = a.ngaycapnhat };
            data.DataSource = result.ToList();
        }
        public bool suaKhachHang(int id, string ten, string email, string matkhau,string sodienthoai, string diachi, DateTime ngaytao)
        {
            DAO.khachhang a = new DAO.khachhang();
            a.id_khachhang = id;
            a.ten = ten;
            a.email = email;
            a.matkhau = matkhau;
            a.sodienthoai = sodienthoai;
            a.diachi = diachi;
            a.ngaytao = ngaytao;
            a.ngaycapnhat = DateTime.Now;
            return DAO.KhachHangDAO.Instance.suaKhachHang(a);
        }
        public bool themKhachHang(string ten, string email, string matkhau, string sodienthoai, string diachi)
        {
            DAO.khachhang a = new DAO.khachhang();
            a.ten = ten;
            a.email = email;
            a.matkhau = matkhau;
            a.sodienthoai = sodienthoai;
            a.diachi = diachi;
            a.ngaycapnhat = DateTime.Now;
            a.ngaytao = DateTime.Now;
            return DAO.KhachHangDAO.Instance.themKhachHang(a);
        }
        public bool timKhachHangbySDT(DataGridView dgv,string sdt)
        {
            DAO.khachhang a = DAO.KhachHangDAO.Instance.findKhachHangbySDT(sdt);
            if (a!= null)
            {
                List<DAO.khachhang> dsKH = new List<DAO.khachhang>();
                dsKH.Add(a);
                dgv.DataSource = new { id = a.id_khachhang, ten = a.ten, email = a.email, matkhau = a.matkhau, sodienthoai = a.sodienthoai, diachi = a.diachi, ngaytao = a.ngaytao, ngaycapnhat = a.ngaycapnhat };
                showSearchResult(dgv, dsKH);
                return true;
            }
            return false;
        }
        public void showSearchResult(DataGridView data, List<DAO.khachhang> dsKH)
        {
            var result = from a in dsKH select new { id = a.id_khachhang, ten = a.ten, email = a.email, matkhau = a.matkhau, sodienthoai = a.sodienthoai, diachi = a.diachi, ngaytao = a.ngaytao, ngaycapnhat = a.ngaycapnhat };
            data.DataSource = result.ToList();
        }
    }
}

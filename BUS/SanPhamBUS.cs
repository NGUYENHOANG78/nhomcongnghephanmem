using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace BUS
{
    public class SanPhamBUS
    {
        private static SanPhamBUS instance;

        public static SanPhamBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanPhamBUS();
                return instance;
            }
        }
        public void showSanPham(DataGridView data)
        {
            var result = from a in DAO.SanPhamDAO.Instance.getListSanPham() select new { id_sanpham = a.id_sanpham, tensanpham = a.tensanpham, gia = a.gia, math = a.id_thuonghieu, maloai = a.id_loai, km = a.khuyenmai,bh = a.baohanh, hinh = a.hinh, ngaytao = a.ngaytao, ngaycapnhat = a.ngaycapnhat, mota = a.mota};
            data.DataSource = result.ToList();
        }
        public void showFromGridviewToCBO(string id, int id_thuonghieu, ComboBox cboNhom, ComboBox cboLoai,ComboBox cboThuongHieu)
        {
            loaisanpham a = LoaiSanPhamDAO.Instance.findLoaiSP(id);
            if(a!=null)
            {
                cboNhom.Text = a.nhomsanpham.tennhom;
                cboLoai.Text = a.tenloai;
            }
            thuonghieu b = ThuongHieuDAO.Instance.findThuongHieu(id_thuonghieu);
            if (b != null)
            {
                cboThuongHieu.Text = b.tenthuonghieu;
            }
        }
        
        public void showImageToPictureBox(string imageName, PictureBox box)
        {
            string imagePath = "..\\..\\image\\" + imageName;
            if(File.Exists(imagePath))
            {
                box.Image = Image.FromFile(imagePath);
                box.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                box.Image = Image.FromFile("..\\..\\image\\notfound.png");
                box.SizeMode = PictureBoxSizeMode.StretchImage;
            }          
        }
        public void showComboboxChanged(DataGridView data, ComboBox cboNhomSP, ComboBox cboLoai, ComboBox cboThuonghieu)
        {
            List<loaisanpham> listLoai = new List<loaisanpham>();
            List<thuonghieu> ListHieu = new List<thuonghieu>();
            nhomsanpham nsp = cboNhomSP.SelectedItem as nhomsanpham;
            if (nsp != null)
            {
                foreach (loaisanpham a in LoaiSanPhamDAO.Instance.getLoaiSP().Where(x => x.id_nhom == nsp.id_nhom))
                {
                    cboLoai.Items.Add(a);
                }
                foreach (thuonghieu b in ThuongHieuDAO.Instance.getListThuongHieu().Where(x => x.id_nhom == nsp.id_nhom))
                {
                    cboThuonghieu.Items.Add(b);
                }
            }
        }
        public bool suaSanPham(string id_sanpham, string tensp, ComboBox loaiSP, decimal gia, ComboBox thuonghieu, int baohanh, int khuyenmai, string hinh, string mota, DateTime ngaytao)
        {
            var lsp = loaiSP.SelectedItem as loaisanpham;
            var th = thuonghieu.SelectedItem as thuonghieu;
            sanpham a = new sanpham();
            if (lsp != null && th != null)
            {
                a.id_sanpham = id_sanpham;
                a.tensanpham = tensp;
                a.id_loai = lsp.id_loai;
                a.id_thuonghieu = th.id_thuonghieu;
                a.gia = gia;
                a.baohanh = baohanh;
                a.khuyenmai = khuyenmai;
                a.hinh = hinh;
                a.mota = mota;
                a.ngaytao = ngaytao;
                a.ngaycapnhat = DateTime.Now;
                a.loaisanpham = lsp;
                a.thuonghieu = th;
            }
            return SanPhamDAO.Instance.suaSanPham(a);
        }
        private string taoMaTuDong()
        {
            Random r = new Random();
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string id = "SP" + day + month;
            int l = 10 - id.Length;
            for(int i = 0; i < l;i++)
            {
                id = id + r.Next(0, 9);
            }
            return id;
        }
        public bool themSanPham(string tensp, ComboBox loaiSP, decimal gia, ComboBox thuonghieu, int baohanh, int khuyenmai, string hinh, string mota)
        {
            var lsp = loaiSP.SelectedItem as loaisanpham;
            var th = thuonghieu.SelectedItem as thuonghieu;
            sanpham a = new sanpham();
            if (lsp != null && th != null)
            {
                a.id_sanpham = taoMaTuDong();
                a.tensanpham = tensp;
                a.id_loai = lsp.id_loai;
                a.id_thuonghieu = th.id_thuonghieu;
                a.gia = gia;
                a.baohanh = baohanh;
                a.khuyenmai = khuyenmai;
                a.hinh = hinh;
                a.mota = mota;
                a.ngaytao = DateTime.Now;
                a.ngaycapnhat = DateTime.Now;
                a.loaisanpham = lsp;
                a.thuonghieu = th;
            }
            return SanPhamDAO.Instance.themSanPham(a);

        }
        public bool xoaNhomSP(string id)
        {
            return SanPhamDAO.Instance.xoaSanPham(id);
        }
        public bool isExistImage(string img)
        {
            string imagePath = "..\\..\\image\\" + img;
            if (File.Exists(imagePath))
            {
                return true;
            }
            return false;
        }
    }
}

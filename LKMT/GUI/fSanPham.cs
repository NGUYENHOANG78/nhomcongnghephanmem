using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
namespace LKMT.GUI
{
    public partial class fSanPham : UserControl
    {
        string newPath = null;
        string path = null;

        public fSanPham()
        {
            InitializeComponent();
            SanPhamBUS.Instance.showSanPham(dgvSanPham);
            dgvSanPham.Columns[0].HeaderText = "Mã linh kiện";
            dgvSanPham.Columns[1].HeaderText = "Tên linh kiện";
            dgvSanPham.Columns[2].HeaderText = "Giá";
            dgvSanPham.Columns[3].HeaderText = "Mã thương hiệu";
            dgvSanPham.Columns[4].HeaderText = "Mã loại";
            dgvSanPham.Columns[5].HeaderText = "Khuyến mãi";
            dgvSanPham.Columns[6].HeaderText = "Bảo hành";
            dgvSanPham.Columns[7].HeaderText = "Hình";
            dgvSanPham.Columns[8].HeaderText = "Ngày tạo";
            dgvSanPham.Columns[9].HeaderText = "Ngày cập nhật";
            dgvSanPham.Columns[10].HeaderText = "Mô tả";


            dgvSanPham.Columns[0].Width = 60;
            dgvSanPham.Columns[1].Width = 170;
            dgvSanPham.Columns[2].Width = 70;
            dgvSanPham.Columns[3].Width = 60;
            dgvSanPham.Columns[4].Width = 60;
            dgvSanPham.Columns[5].Width = 50;
            dgvSanPham.Columns[6].Width = 50;
            dgvSanPham.Columns[7].Width = 80;
            dgvSanPham.Columns[8].Width = 70;
            dgvSanPham.Columns[9].Width = 70;
            dgvSanPham.Columns[9].Width = 150;

            cboLoaiLK.DisplayMember = "tenloai";
            cboThuongHieu.DisplayMember = "tenthuonghieu";

            NhomSanPhamBUS.Instance.showListNhomSP(cboNhomLK);
        }

        private void fSanPham_Load(object sender, EventArgs e)
        {

        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select image to be upload.";
            //which type image format you want to upload in database. just add them.
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                        newPath = "..\\..\\image\\" + fileName;
                        lbPath.Text = fileName;
                        pictureLinhKien.Image = new Bitmap(openFileDialog1.FileName);
                        pictureLinhKien.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvSanPham.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                    txtMaLinhKien.Text = row.Cells[0].Value.ToString();
                    txtTenLinhKien.Text = row.Cells[1].Value.ToString();
                    txtGia.Text = row.Cells[2].Value.ToString();
                    SanPhamBUS.Instance.showFromGridviewToCBO(row.Cells[4].Value.ToString(), int.Parse(row.Cells[3].Value.ToString()), cboNhomLK, cboLoaiLK,cboThuongHieu);
                    nmrKhuyenMai.Value = int.Parse(row.Cells[5].Value.ToString());
                    nmrBaoHanh.Value = int.Parse(row.Cells[6].Value.ToString());
                    SanPhamBUS.Instance.showImageToPictureBox(row.Cells[7].Value.ToString(), pictureLinhKien);
                    lbPath.Text = row.Cells[7].Value.ToString();
                    txtNgayTao.Text = row.Cells[8].Value.ToString();
                    txtCapNhat.Text = row.Cells[9].Value.ToString();
                    richMoTa.Text = row.Cells[10].Value.ToString();
                }               
            }        
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboNhomLK_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboThuongHieu.Items.Clear();
            cboLoaiLK.Items.Clear();
            cboLoaiLK.Text = null;
            cboThuongHieu.Text = null;

            SanPhamBUS.Instance.showComboboxChanged(dgvSanPham, cboNhomLK, cboLoaiLK, cboThuongHieu);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLinhKien.TextLength > 10)
            {
                MessageBox.Show("Mã không được vượt quá 10 ký tự!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else if (txtTenLinhKien.TextLength == 0)
                MessageBox.Show("Tên không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
            else if (txtGia.TextLength == 0)
                MessageBox.Show("Giá không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
            else if (cboLoaiLK.Text.Length == 0)
                MessageBox.Show("Loại linh kiện không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
            else if (cboThuongHieu.Text.Length == 0)
                MessageBox.Show("Thương hiệu không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
            else if (path == null)
                MessageBox.Show("Chọn hình cho linh kiện!!", "Thông Báo", MessageBoxButtons.OK);
            else
            {
                if (SanPhamBUS.Instance.themSanPham(txtTenLinhKien.Text, cboLoaiLK, decimal.Parse(txtGia.Text), cboThuongHieu, (int)nmrBaoHanh.Value, (int)nmrKhuyenMai.Value, lbPath.Text, richMoTa.Text))
                {
                    MessageBox.Show("Thêm linh kiện thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    SanPhamBUS.Instance.showSanPham(dgvSanPham);
                    if(SanPhamBUS.Instance.isExistImage(lbPath.Text) == false)
                    {
                        System.IO.File.Copy(path, newPath,true);
                    }
                    path = null;
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Thêm linh kiện thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvSanPham.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount>0)
            {
                if (SanPhamBUS.Instance.suaSanPham(txtMaLinhKien.Text, txtTenLinhKien.Text, cboLoaiLK, decimal.Parse(txtGia.Text), cboThuongHieu, (int)nmrBaoHanh.Value, (int)nmrKhuyenMai.Value, lbPath.Text, richMoTa.Text, DateTime.Parse(txtNgayTao.Text)))
                {
                    MessageBox.Show("Cập nhật thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    SanPhamBUS.Instance.showSanPham(dgvSanPham);
                    if (path != null)
                    {
                        if (SanPhamBUS.Instance.isExistImage(lbPath.Text) == false)
                        {
                            System.IO.File.Copy(path, newPath, true);
                        }
                    }
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Cập nhật thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn linh kiện muốn cập nhật!!", "Thông Báo", MessageBoxButtons.OK);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (SanPhamBUS.Instance.xoaNhomSP(txtMaLinhKien.Text))
            {
                MessageBox.Show("Xóa linh kiện thành công!!", "Thông Báo", MessageBoxButtons.OK);
                SanPhamBUS.Instance.showSanPham(dgvSanPham);
                btnLamMoi_Click(sender, e);
            }
            else MessageBox.Show("Xóa linh kiện thất bại!!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {     
            txtMaLinhKien.Text = null;
            txtTenLinhKien.Text = null;
            txtGia.Text = null;
            cboLoaiLK.Text = null;
            cboThuongHieu.Text = null;
            nmrBaoHanh.Value = 0;
            nmrKhuyenMai.Value = 0;
            richMoTa.Text = null;
            pictureLinhKien.Image = null;
        }
    }
}

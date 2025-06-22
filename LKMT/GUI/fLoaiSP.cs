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
    public partial class fLoaiSP : UserControl
    {
        public fLoaiSP()
        {
            InitializeComponent();
            LoaiSanPhamBUS.Instance.showLoaiSP(dgvLoaiSP);
            dgvLoaiSP.Columns[0].HeaderText = "Ma loai";
            dgvLoaiSP.Columns[1].HeaderText = "Ten loai";
            dgvLoaiSP.Columns[2].HeaderText = "Ten nhom";
            dgvLoaiSP.Columns[3].HeaderText = "Ngay tao";
            dgvLoaiSP.Columns[4].HeaderText = "Ngay cap nhat";
            dgvLoaiSP.Columns[0].Width = 50;
            dgvLoaiSP.Columns[1].Width = 170;
            dgvLoaiSP.Columns[2].Width = 100;
            dgvLoaiSP.Columns[3].Width = 80;
            dgvLoaiSP.Columns[4].Width = 80;
            NhomSanPhamBUS.Instance.showListNhomSP(cboNhomLK);
        }

        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvLoaiSP.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)            
            {
                if(e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvLoaiSP.Rows[e.RowIndex];
                    txtMaLoai.Text = row.Cells[0].Value.ToString();
                    txtTenLoai.Text = row.Cells[2].Value.ToString();
                    NhomSanPhamBUS.Instance.showTenNhomToCBO(row.Cells[2].Value.ToString(), cboNhomLK);
                    txtNgayTao.Text = row.Cells[3].Value.ToString();
                    txtCapNhat.Text = row.Cells[4].Value.ToString();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenLoai.Text = "";
            txtMaLoai.Text = "";
            txtNgayTao.Text = "";
            txtCapNhat.Text = "";
        }

        private void cboNhomLK_SelectedIndexChanged(object sender, EventArgs e)
        {
             LoaiSanPhamBUS.Instance.showListLoaiSP(dgvLoaiSP, cboNhomLK);

        }

        private void fLoaiSP_Load(object sender, EventArgs e)
        {
            LoaiSanPhamBUS.Instance.showListLoaiSP(dgvLoaiSP, cboNhomLK);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvLoaiSP.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)           
            {
                if (LoaiSanPhamBUS.Instance.suaLoaiSP(txtMaLoai.Text, cboNhomLK, txtTenLoai.Text, DateTime.Parse(txtNgayTao.Text)))
                {
                    MessageBox.Show("Cap nhat thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    LoaiSanPhamBUS.Instance.showListLoaiSP(dgvLoaiSP, cboNhomLK);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Cap nhat that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui long chon loai linh kien muon cap nhat!!", "Thong Bao", MessageBoxButtons.OK);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.TextLength > 5)
            {
                MessageBox.Show("Ma khong duoc vuot qua 5 ky tu!!", "Thong Bao", MessageBoxButtons.OK);
            }        
            else if (txtTenLoai.TextLength == 0)
                MessageBox.Show("Ten khong duoc bo trong!!", "Thong Bao", MessageBoxButtons.OK);
            else
            {
                if (LoaiSanPhamBUS.Instance.themLoaiSP(cboNhomLK, txtTenLoai.Text))
                {
                    MessageBox.Show("Them loai linh kien thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    LoaiSanPhamBUS.Instance.showListLoaiSP(dgvLoaiSP, cboNhomLK);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Them loai linh kien that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvLoaiSP.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (LoaiSanPhamBUS.Instance.xoaLoaiSP(txtMaLoai.Text))
                {
                    MessageBox.Show("Xoa loai linh kien thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    LoaiSanPhamBUS.Instance.showListLoaiSP(dgvLoaiSP, cboNhomLK);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Xoa loai linh kien that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui long chon loai linh kien muon xoa!!", "Thong Bao", MessageBoxButtons.OK);
            }          
        }

        private void cboNhomLK_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvLoaiSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
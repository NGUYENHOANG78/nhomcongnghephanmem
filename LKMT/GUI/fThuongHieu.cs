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
    public partial class fThuongHieu : UserControl
    {
        public fThuongHieu()
        {
            InitializeComponent();
            ThuongHieuBUS.Instance.showListThuongHieu(dgvThuongHieu);
            dgvThuongHieu.Columns[0].HeaderText = "Ma thuong hieu";
            dgvThuongHieu.Columns[1].HeaderText = "Ten thuong hieu";
            dgvThuongHieu.Columns[2].HeaderText = "ID nhom";
            dgvThuongHieu.Columns[3].HeaderText = "Ngay tao";
            dgvThuongHieu.Columns[4].HeaderText = "Ngay cap nhat";
            dgvThuongHieu.Columns[0].Width = 50;
            dgvThuongHieu.Columns[1].Width = 170;
            dgvThuongHieu.Columns[2].Width = 100;
            dgvThuongHieu.Columns[3].Width = 80;
            dgvThuongHieu.Columns[4].Width = 80;
            NhomSanPhamBUS.Instance.showListNhomSP(cboNhomLK);
        }

        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvThuongHieu.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvThuongHieu.Rows[e.RowIndex];
                    txtMaTH.Text = row.Cells[0].Value.ToString();
                    txtTenThuongHieu.Text = row.Cells[2].Value.ToString();
                    NhomSanPhamBUS.Instance.showTenNhomToCBO(row.Cells[2].Value.ToString(), cboNhomLK);
                    txtNgayTao.Text = row.Cells[3].Value.ToString();
                    txtNgayCapNhat.Text = row.Cells[4].Value.ToString();
                }          
            }         
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaTH.Text = "";
            txtTenThuongHieu.Text = "";
            txtNgayCapNhat.Text = "";
            txtNgayTao.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
          
            if (txtTenThuongHieu.TextLength == 0)
                MessageBox.Show("Ten khong duoc bo trong!!", "Thong Bao", MessageBoxButtons.OK);
            else
            {
                if (ThuongHieuBUS.Instance.themThuongHieu(txtMaTH.Text,txtTenThuongHieu.Text, cboNhomLK))
                {
                    MessageBox.Show("Them thuong hieu thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    ThuongHieuBUS.Instance.showListThuongHieu(dgvThuongHieu, cboNhomLK);
                }
                else MessageBox.Show("Them thuong hieu that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvThuongHieu.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (ThuongHieuBUS.Instance.suaThuongHieu(int.Parse(txtMaTH.Text), txtTenThuongHieu.Text, cboNhomLK, DateTime.Parse(txtNgayTao.Text)))
                {
                    MessageBox.Show("Cap nhat thuong hieu thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    ThuongHieuBUS.Instance.showListThuongHieu(dgvThuongHieu, cboNhomLK);
                }
                else MessageBox.Show("Cap nhat thuong hieu that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui long chon thuong hieu muon cap nhat!!", "Thong Bao", MessageBoxButtons.OK);
            }         
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvThuongHieu.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (ThuongHieuBUS.Instance.xoaThuongHieu(int.Parse(txtMaTH.Text)))
                {
                    MessageBox.Show("Xoa thuong hieu thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    ThuongHieuBUS.Instance.showListThuongHieu(dgvThuongHieu, cboNhomLK);
                }
                else MessageBox.Show("Xoa thuong hieu that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui long chon thuong hieu muon cap nhat!!", "Thong Bao", MessageBoxButtons.OK);
            }
           
        }

        private void cboNhomLK_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThuongHieuBUS.Instance.showListThuongHieu(dgvThuongHieu, cboNhomLK);
        }

        private void fThuongHieu_Load(object sender, EventArgs e)
        {
            ThuongHieuBUS.Instance.showListThuongHieu(dgvThuongHieu, cboNhomLK);

        }
    }
}
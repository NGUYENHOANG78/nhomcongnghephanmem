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
    public partial class fKhachHang : UserControl
    {
        public fKhachHang()
        {
            InitializeComponent();
            KhachHangBUS.Instance.showKhachHang(dgvKhachHang);
            dgvKhachHang.Columns[0].HeaderText = "Ma khach hang";
            dgvKhachHang.Columns[1].HeaderText = "Ten khach hang";
            dgvKhachHang.Columns[2].HeaderText = "Email";
            dgvKhachHang.Columns[3].HeaderText = "Mat khau";
            dgvKhachHang.Columns[4].HeaderText = "So dien thoai";
            dgvKhachHang.Columns[5].HeaderText = "Dia chi";
            dgvKhachHang.Columns[6].HeaderText = "Ngay tao";
            dgvKhachHang.Columns[7].HeaderText = "Ngay cap nhat";

            dgvKhachHang.Columns[0].Width = 50;
            dgvKhachHang.Columns[1].Width = 170;
            dgvKhachHang.Columns[2].Width = 100;
            dgvKhachHang.Columns[3].Width = 80;
            dgvKhachHang.Columns[4].Width = 80;
            dgvKhachHang.Columns[5].Width = 120;
            dgvKhachHang.Columns[6].Width = 80;
            dgvKhachHang.Columns[7].Width = 80;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenKH.TextLength == 0)
                MessageBox.Show("Ten khong duoc bo trong!!", "Thong Bao", MessageBoxButtons.OK);
            else if (txtDienThoai.TextLength == 0)
                MessageBox.Show("So dien thoai khong duoc bo trong!!", "Thong Bao", MessageBoxButtons.OK);
            else
            {
                if (KhachHangBUS.Instance.themKhachHang(txtTenKH.Text, txtEmail.Text, txtMatKhau.Text, txtDienThoai.Text, txtDiaChi.Text))
                {
                    MessageBox.Show("Them khach hang thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    KhachHangBUS.Instance.showKhachHang(dgvKhachHang);
                    btnLamMoi_Click(sender, e);
                }
                else
                    MessageBox.Show("Them khach hang that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvKhachHang.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                    txtMaKH.Text = row.Cells[0].Value.ToString();
                    txtTenKH.Text = row.Cells[1].Value.ToString();
                    txtEmail.Text = row.Cells[2].Value.ToString();
                    txtMatKhau.Text = row.Cells[3].Value.ToString();
                    txtDienThoai.Text = row.Cells[4].Value.ToString();
                    txtDiaChi.Text = row.Cells[5].Value.ToString();
                    txtNgayTao.Text = row.Cells[6].Value.ToString();
                    txtCapNhat.Text = row.Cells[7].Value.ToString();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtCapNhat.Text = null;
            txtDiaChi.Text = null;
            txtDienThoai.Text = null;
            txtEmail.Text = null;
            txtMaKH.Text = null;
            txtMatKhau.Text = null;
            txtNgayTao.Text = null;
            txtTenKH.Text = null;
            txtSearchBox.Text = null;
            KhachHangBUS.Instance.showKhachHang(dgvKhachHang);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvKhachHang.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (KhachHangBUS.Instance.suaKhachHang(int.Parse(txtMaKH.Text), txtTenKH.Text, txtEmail.Text, txtMatKhau.Text, txtDienThoai.Text, txtDiaChi.Text, DateTime.Parse(txtNgayTao.Text)))
                {
                    MessageBox.Show("Cap nhat khach hang thanh cong!!", "Thong Bao", MessageBoxButtons.OK);
                    KhachHangBUS.Instance.showKhachHang(dgvKhachHang);
                    btnLamMoi_Click(sender, e);
                }
                else
                    MessageBox.Show("Cap nhat khach hang that bai!!", "Thong Bao", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui long chon khach hang muon cap nhat!!", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSearchBox.TextLength == 0)
                MessageBox.Show("Vui long nhap so dien thoai!!", "Thong Bao", MessageBoxButtons.OK);
            if (KhachHangBUS.Instance.timKhachHangbySDT(dgvKhachHang, txtSearchBox.Text))
                MessageBox.Show("Khong tim thay khach hang co so dien thoai " + txtSearchBox.Text, "Thong Bao", MessageBoxButtons.OK);
        }
    }
}

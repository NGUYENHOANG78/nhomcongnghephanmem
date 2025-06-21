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
            dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns[2].HeaderText = "Email";
            dgvKhachHang.Columns[3].HeaderText = "Mật khẩu";
            dgvKhachHang.Columns[4].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns[5].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[6].HeaderText = "Ngày tạo";
            dgvKhachHang.Columns[7].HeaderText = "Ngày cập nhật";

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
                MessageBox.Show("Tên không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
           else if (txtDienThoai.TextLength == 0)
                MessageBox.Show("Số điện thoại không được bỏ trống!!", "Thông Báo", MessageBoxButtons.OK);
            else
            {
                if (KhachHangBUS.Instance.themKhachHang(txtTenKH.Text,txtEmail.Text,txtMatKhau.Text,txtDienThoai.Text,txtDiaChi.Text))
                {
                    MessageBox.Show("Thêm khách hàng thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    KhachHangBUS.Instance.showKhachHang(dgvKhachHang);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Thêm khách hàng thất bại!!", "Thông Báo", MessageBoxButtons.OK);
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
                if (KhachHangBUS.Instance.suaKhachHang(int.Parse(txtMaKH.Text),txtTenKH.Text, txtEmail.Text, txtMatKhau.Text, txtDienThoai.Text, txtDiaChi.Text, DateTime.Parse(txtNgayTao.Text)))
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    KhachHangBUS.Instance.showKhachHang(dgvKhachHang);
                    btnLamMoi_Click(sender, e);
                }
                else MessageBox.Show("Cập nhật khách hàng thất bại!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng muốn cập nhật!!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSearchBox.TextLength == 0)
                MessageBox.Show("Vui lòng nhập số điện thoại!!", "Thông Báo", MessageBoxButtons.OK);
            if(KhachHangBUS.Instance.timKhachHangbySDT(dgvKhachHang,txtSearchBox.Text))        
                 MessageBox.Show("Không tìm thấy khách hàng có số điện thoại " + txtSearchBox.Text, "Thông Báo", MessageBoxButtons.OK);

        }
    }
}

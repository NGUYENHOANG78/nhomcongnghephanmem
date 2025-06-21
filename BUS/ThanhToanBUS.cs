using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class ThanhToanBUS
    {
        private static ThanhToanBUS instance;

        public static ThanhToanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThanhToanBUS();
                return instance;
            }
        }
        public void showThanhToan(DataGridView data)
        {
            var result = from a in DAO.ThanhToanDAO.Instance.getListThanhToan() select new { id = a.id_thanhtoan, tenthanhtoan = a.tenthanhtoan};
            data.DataSource = result.ToList();
        }
        public bool suaThanhToan(int id, string ten)
        {
            DAO.phuongthucthanhtoan a = new DAO.phuongthucthanhtoan();
            a.id_thanhtoan = id;
            a.tenthanhtoan = ten;          
            return DAO.ThanhToanDAO.Instance.suaThanhToan(a);
        }
        public bool themThanhToan(string ten)
        {
            DAO.phuongthucthanhtoan a = new DAO.phuongthucthanhtoan();
            a.tenthanhtoan = ten;         
            return DAO.ThanhToanDAO.Instance.themThanhToan(a);
        }
        public bool xoaThanhToan(int id)
        {
            return DAO.ThanhToanDAO.Instance.xoaThanhToan(id);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class DangNhapBUS
    {

        public bool checkLogin(string email, string pass)
        {
            List<admin> dsAdmin = new List<admin>();
            DangNhapDAO dn = new DangNhapDAO();
            dsAdmin = dn.getAdmins();
            foreach(var i in dsAdmin)
            {
                if (i.email == email && i.matkhau == pass)
                    return true;
            }
            return false;
        }
    }
}

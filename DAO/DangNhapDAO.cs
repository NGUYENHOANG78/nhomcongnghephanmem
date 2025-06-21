using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class DangNhapDAO
    {
        public List<admin> getAdmins()
        {
            List<admin> dsAdmin = new List<admin>();
            dsAdmin = DataProvider.Ins.DB.admins.ToList();
            return dsAdmin;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketDal
{
    public class LoginDal
    {
        public List<employee> LoginSel(string name = "", string passward = "")
        {
            SuperMarketDB db = new SuperMarketDB();
            var query = db.employee.Where(o => o.EmpName == name && o.EmpPwd == passward).ToList();
            return query;
        }

        public List<employee> List()
        {
            SuperMarketDB db = new SuperMarketDB();
            List<employee> emp = db.employee.ToList();
            return emp;
        }
    }
}

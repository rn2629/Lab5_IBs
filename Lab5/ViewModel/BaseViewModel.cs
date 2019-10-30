using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.ViewModel
{
    class BaseViewModel
    {
        static string connectionString = @"Data Source=deptinfo420;Initial Catalog = RodBD; Integrated Security = True";
        protected static SqlConnection con;

        public BaseViewModel()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper
{
    internal class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=PC-232-11\SQLEXPRESS;Initial Catalog=TermPaper;User ID=U-19;Password=19$RPEe");
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

    }
}

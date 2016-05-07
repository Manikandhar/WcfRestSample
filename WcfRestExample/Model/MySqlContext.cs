using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WcfRestExample.Model
{
    public class MySqlContext
    {
        private readonly string connectionString;

        public MySqlContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbString"].ToString();
        }

        public DataSet GetResult(string query)
        {
            var connection = new MySqlConnection(connectionString);
            var adapter = new MySqlDataAdapter(query, connection);

            var ds = new DataSet();
            adapter.Fill(ds, "actors");

            return ds;

        }

    }
}
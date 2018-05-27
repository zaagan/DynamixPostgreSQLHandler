using System.Data;
using Npgsql;

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {

        public DataTable ExecuteSQL(string sqlQuery)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                DataSet dataSet = new DataSet();

                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlQuery, conn))
                {
                    dataSet.Reset();
                    da.Fill(dataSet);
                    conn.Close();
                }

                DataTable table = null;
                if (dataSet != null && dataSet.Tables != null && dataSet.Tables[0] != null)
                {
                    table = dataSet.Tables[0];
                }
                return table;
            }
        }



    }
}

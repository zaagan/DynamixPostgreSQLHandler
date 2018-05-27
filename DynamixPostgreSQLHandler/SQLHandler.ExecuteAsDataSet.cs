using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {

        /// <summary>
        /// Execute as DataSet.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <returns>Object of DataSet.</returns>
        public DataSet ExecuteAsDataSet(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;


                for (int i = 0; i < parameterCollection.Count; i++)
                {
                    NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = parameterCollection[i].Key;
                    sqlParaMeter.Value = parameterCollection[i].Value;
                    command.Parameters.Add(sqlParaMeter);
                }
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = command;

                DataSet dataSet = new DataSet();

                conn.Open();
                adapter.Fill(dataSet);

                return dataSet;
            }
        }




        /// <summary>
        /// Execute as DataSet.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <returns>Object of DataSet.</returns>
        public DataSet ExecuteAsDataSet(string storedProcedureName, List<KeyValuePair<string, string>> parameterCollection)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < parameterCollection.Count; i++)
                {
                    command.Parameters.Add(new NpgsqlParameter(parameterCollection[i].Key, parameterCollection[i].Value));
                }

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = command;

                DataSet dataSet = new DataSet();

                conn.Open();
                adapter.Fill(dataSet);

                return dataSet;
            }
        }




        /// <summary>
        /// Execute As DataSet
        /// </summary>
        /// <param name="storedProcedureName">StoreProcedure Name</param>
        /// <returns>Object of DataSet.</returns>
        public DataSet ExecuteAsDataSet(string storedProcedureName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = command;

                DataSet dataSet = new DataSet();

                conn.Open();
                adapter.Fill(dataSet);

                return dataSet;
            }
        }





    }
}

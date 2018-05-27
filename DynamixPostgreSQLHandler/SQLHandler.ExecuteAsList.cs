using System.Collections.Generic;
using System.Data;
using DynamixPostgreSQLHandler.Helpers;
using Npgsql;

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {

        /// <summary>
        /// Execute As List.
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="sqlQuery">Sql Query.</param>
        /// <returns>Type of list of object implementing.</returns>
        public List<T> ExecuteAsListUsingQuery<T>(string sqlQuery)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = sqlQuery;
                command.CommandType = CommandType.Text;

                conn.Open();
                NpgsqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<T> mList = new List<T>();
                mList = DataSourceHelper.FillCollection<T>(reader);
                if (reader != null)
                {
                    reader.Close();
                }
                reader.Close();
                return mList;
            }
        }



        /// <summary>
        /// Execute As List.
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="storedProcedureName">Storedprocedure name.</param>
        /// <returns>Type of list of object implementing.</returns>
        public List<T> ExecuteAsList<T>(string storedProcedureName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();
                NpgsqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<T> mList = new List<T>();
                mList = DataSourceHelper.FillCollection<T>(reader);
                if (reader != null)
                {
                    reader.Close();
                }
                reader.Close();
                return mList;
            }
        }



        /// <summary>
        /// Execute as list.
        /// </summary>
        /// <typeparam name="T">Given type of object</typeparam>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Accept Key Value collection for parameters.</param>
        /// <returns>Type of list of object implementing.</returns>
        public List<T> ExecuteAsList<T>(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection)
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

                conn.Open();
                NpgsqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<T> mList = new List<T>();
                mList = DataSourceHelper.FillCollection<T>(reader);
                if (reader != null)
                {
                    reader.Close();
                }
                reader.Close();
                return mList;
            }
        }





    }
}

using System.Collections.Generic;
using System.Data;
using DynamixPostgreSQLHandler.Helpers;
using Npgsql;

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {

        /// <summary>
        /// Execute As scalar.
        /// </summary>
        /// <typeparam name="T"> Given type of object.</typeparam>
        /// <param name="stroredProcedureName">Store procedure name</param>
        /// <returns>Type of the object implementing</returns>
        public T ExecuteAsScalar<T>(string stroredProcedureName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = stroredProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();
                return (T)command.ExecuteScalar();
            }
        }



        /// <summary>
        /// Execute As scalar .
        /// </summary>
        /// <typeparam name="T"> Given type of object.</typeparam>
        /// <param name="stroredProcedureName">Store procedure name</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <returns>Type of the object implementing</returns>
        public T ExecuteAsScalar<T>(string stroredProcedureName, List<KeyValuePair<string, object>> parameterCollection)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = stroredProcedureName;
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
                return (T)command.ExecuteScalar();
            }
        }




    }
}

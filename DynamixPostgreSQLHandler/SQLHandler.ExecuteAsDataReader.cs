using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {

        /// <summary>
        /// Execute as DataReader.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <returns>Object of SqlDataReader.</returns>
        public NpgsqlDataReader ExecuteAsDataReader(string storedProcedureName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();
                NpgsqlDataReader SQLReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return SQLReader;
            }
        }




        /// <summary>
        /// Execute as DataReader.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name. </param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <returns>Object of SqlDataReader.</returns>
        public NpgsqlDataReader ExecuteAsDataReader(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection)
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
                NpgsqlDataReader SQLReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return SQLReader;
            }
        }





        /// <summary>
        /// Execute as DataReader.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <returns>Object of SqlDataReader.</returns>
        public NpgsqlDataReader ExecuteAsDataReader(string storedProcedureName, List<KeyValuePair<string, string>> parameterCollection)
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


                conn.Open();
                NpgsqlDataReader SQLReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return SQLReader;
            }
        }









    }
}

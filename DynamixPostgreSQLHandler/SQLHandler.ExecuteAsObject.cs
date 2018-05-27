using System.Collections;
using System.Collections.Generic;
using System.Data;
using DynamixPostgreSQLHandler.Helpers;
using Npgsql;

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {

        /// <summary>
        /// Execute As Object
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <returns>Type of list of object implementing.</returns>
        public T ExecuteAsObjectUsingQuery<T>(string sqlQuery)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = sqlQuery;
                command.CommandType = CommandType.Text;

                conn.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                ArrayList arrColl = DataSourceHelper.FillCollection(reader, typeof(T));
                conn.Close();

                if (reader != null)
                    reader.Close();

                if (arrColl != null && arrColl.Count > 0)
                    return (T)arrColl[0];
                else
                    return default(T);
            }
        }



        /// <summary>
        /// Execute As Object
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="storedProcedureName">Accept Key Value Collection For Parameters</param>
        /// <returns> Type of the object implementing</returns>
        public T ExecuteAsObject<T>(string storedProcedureName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                ArrayList arrColl = DataSourceHelper.FillCollection(reader, typeof(T));
                conn.Close();

                if (reader != null)
                    reader.Close();

                if (arrColl != null && arrColl.Count > 0)
                    return (T)arrColl[0];
                else
                    return default(T);
            }


        }



        /// <summary>
        /// Execute as object.
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="paraMeterCollection">Accept key value collection for parameters.</param>
        /// <returns></returns>
        public T ExecuteAsObject<T>(string storedProcedureName, List<KeyValuePair<string, object>> paraMeterCollection)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < paraMeterCollection.Count; i++)
                {
                    NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = paraMeterCollection[i].Key;
                    sqlParaMeter.Value = paraMeterCollection[i].Value;
                    command.Parameters.Add(sqlParaMeter);
                }

                conn.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                ArrayList arrColl = DataSourceHelper.FillCollection(reader, typeof(T));
                conn.Close();

                if (reader != null)
                    reader.Close();

                if (arrColl != null && arrColl.Count > 0)
                    return (T)arrColl[0];
                else
                    return default(T);
            }


        }


    }
}

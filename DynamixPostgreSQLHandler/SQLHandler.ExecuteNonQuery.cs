using System.Collections.Generic;
using System.Data;
using DynamixPostgreSQLHandler.Helpers;
using Npgsql;

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {


        /// <summary>
        /// Executes non query.
        /// </summary>
        /// <param name="sqlScript">SQL Script</param>
        /// <param name="timeout">Timeout </param>
        public void ExecuteNonQueryUsingSQL(string sqlScript, int timeout = 0)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = sqlScript;
                command.CommandType = CommandType.Text;

                conn.Open();
                command.CommandTimeout = timeout;
                command.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// Executes non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        public void ExecuteNonQuery(string storedProcedureName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();
                command.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Execute non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="outputParameterName">Accept Output for parameters name.</param>
        /// <returns>Integer value.</returns>
        public int ExecuteNonQuery(string storedProcedureName, string outputParameterName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
                conn.Open();
                command.ExecuteNonQuery();
                int returnValue = (int)command.Parameters[outputParameterName].Value;
                return returnValue;
            }
        }


        /// <summary>
        /// Execute non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="outputParameterName">Accept output for parameter name.</param>
        /// <param name="outputParameterValue">Accept output for parameter value.</param>
        /// <returns>Integer value.</returns>
        public int ExecuteNonQuery(string storedProcedureName, string outputParameterName, object outputParameterValue)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
                command.Parameters[outputParameterName].Value = outputParameterValue;
                conn.Open();
                command.ExecuteNonQuery();
                int returnValue = (int)command.Parameters[outputParameterName].Value;
                return returnValue;
            }
        }


        /// <summary>
        /// Executes non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters. <KeyValuePair<string, string>> </param>
        public void ExecuteNonQuery(string storedProcedureName, List<KeyValuePair<string, string>> parameterCollection)
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
                command.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Executes non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters. <KeyValuePair<string, string>> </param>
        public void ExecuteNonQuery(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection)
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
                command.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Returning bool after execute non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Parameter collection.</param>
        /// <param name="outputParameterName">OutPut parameter name.</param>
        /// <param name="outputParameterValue">OutPut parameter value.</param>
        /// <returns>Bool</returns>
        public bool ExecuteNonQueryAsBool(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection, string outputParameterName, object outputParameterValue)
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

                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Bit));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
                command.Parameters[outputParameterName].Value = outputParameterValue;

                conn.Open();
                command.ExecuteNonQuery();
                bool returnValue = (bool)command.Parameters[outputParameterName].Value;
                return returnValue;
            }
        }


        /// <summary>
        /// Execute non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name in string.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <param name="outputParameterName">Accept output key value collection for parameters.</param>
        /// <returns>Integer value.</returns>
        public int ExecuteNonQuery(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection, string outputParameterName)
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

                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;

                conn.Open();
                command.ExecuteNonQuery();
                int returnValue = (int)command.Parameters[outputParameterName].Value;
                return returnValue;
            }
        }


        /// <summary>
        /// Execute non query.
        /// </summary>
        /// <param name="storedProcedureName"> Store procedure name.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <param name="outputParameterName">Accept output key value collection for parameters.</param>
        /// <returns>Integer value.</returns>
        public int ExecuteNonQuery(string storedProcedureName, List<KeyValuePair<string, string>> parameterCollection, string outputParameterName)
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

                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;

                conn.Open();
                command.ExecuteNonQuery();
                int returnValue = (int)command.Parameters[outputParameterName].Value;
                return returnValue;
            }
        }


        /// <summary>
        /// Execute non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <param name="outputParameterName">Accept output  for parameters name.</param>
        /// <param name="outputParameterValue">Accept output for parameters value.</param>
        /// <returns>Integer value.</returns>
        public int ExecuteNonQuery(string storedProcedureName, List<KeyValuePair<string, string>> parameterCollection, string outputParameterName, object outputParameterValue)
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

                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
                command.Parameters[outputParameterName].Value = outputParameterValue;

                conn.Open();
                command.ExecuteNonQuery();
                int returnValue = (int)command.Parameters[outputParameterName].Value;
                return returnValue;
            }
        }



        /// <summary>
        /// Returning bool after execute non query.
        /// </summary>
        /// <param name="storedProcedureName">Store procedure name.</param>
        /// <param name="parameterCollection"> Parameter collection.</param>
        /// <param name="outputParameterName">Out parameter collection.</param>
        /// <returns>Bool</returns>
        public bool ExecuteNonQueryAsBool(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection, string outputParameterName)
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

                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Bit));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;

                conn.Open();
                command.ExecuteNonQuery();
                bool returnValue = (bool)command.Parameters[outputParameterName].Value;
                return returnValue;
            }
        }


        /// <summary>
        /// Accept only int, Int16, long, DateTime, string (NVarcha of size  50),
        /// bool, decimal ( of size 16,2), float
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="storedProcedureName">Accet SQL procedure name in string.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <param name="outputParameterName">Accept output parameter for the stored procedures.</param>
        /// <returns>Type of the object implementing.</returns>
        public T ExecuteNonQueryAsGivenType<T>(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection, string outputParameterName)
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

                command = DataSourceHelper.AddOutPutParametrofGivenType<T>(command, outputParameterName);
                conn.Open();
                command.ExecuteNonQuery();
                return (T)command.Parameters[outputParameterName].Value;
            }
        }


        /// <summary>
        /// Accept only int, Int16, long, DateTime, string (NVarcha of size  50),
        /// bool, decimal ( of size 16,2), float
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="storedProcedureName">Accept SQL procedure name in string.</param>
        /// <param name="parameterCollection">Accept key value collection for parameters.</param>
        /// <param name="outputParameterName">Accept output parameter for the stored procedures.</param>
        /// <param name="outputParameterValue">OutPut parameter value.</param>
        /// <returns>Type of the object implementing.</returns>
        public T ExecuteNonQueryAsGivenType<T>(string storedProcedureName, List<KeyValuePair<string, object>> parameterCollection, string outputParameterName, object outputParameterValue)
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

                command = DataSourceHelper.AddOutPutParametrofGivenType<T>(command, outputParameterName, outputParameterValue);
                conn.Open();
                command.ExecuteNonQuery();
                return (T)command.Parameters[outputParameterName].Value; ;
            }
        }




        /// <summary>
        /// Executes non query with multipal output.
        /// </summary>
        /// <param name="storedProcedureName">Strored procedure name.</param>
        /// <param name="inputParamColl">Accept Key Value collection for parameters.</param>
        /// <param name="outputParamColl">Output Key Value collection for parameters.</param>
        /// <returns>List Key Value collection</returns>
        public List<KeyValuePair<string, object>> ExecuteNonQueryWithMultipleOutputStringObject(string storedProcedureName, List<KeyValuePair<string, object>> inputParamColl, List<KeyValuePair<string, object>> outputParamColl)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> kvp in inputParamColl)
                {
                    NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = kvp.Key;
                    sqlParaMeter.Value = kvp.Value;
                    command.Parameters.Add(sqlParaMeter);
                }

                foreach (KeyValuePair<string, object> kvp in outputParamColl)
                {
                    NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = kvp.Key;
                    sqlParaMeter.Value = kvp.Value;
                    sqlParaMeter.Direction = ParameterDirection.InputOutput;
                    sqlParaMeter.Size = 256;
                    command.Parameters.Add(sqlParaMeter);
                }

                conn.Open();
                command.ExecuteNonQuery();
                List<KeyValuePair<string, object>> lstRetValues = new List<KeyValuePair<string, object>>();
                for (int i = 0; i < outputParamColl.Count; i++)
                {
                    lstRetValues.Add(new KeyValuePair<string, object>(i.ToString(), command.Parameters[inputParamColl.Count + i].Value.ToString()));
                }
                return lstRetValues;
            }
        }




        /// <summary>
        /// Executes non query with multipal output.
        /// </summary>
        /// <param name="transaction"> Transact-SQL transaction </param>
        /// <param name="commandType">Command type</param>
        /// <param name="storedProcedureName">Strored procedure name.</param>
        /// <param name="inputParamColl">Accept Key Value collection for parameters.</param>
        /// <param name="outputParamColl">Output Key Value collection for parameters.</param>
        /// <returns>List Key Value collection</returns>
        public List<KeyValuePair<int, string>> ExecuteNonQueryWithMultipleOutput(NpgsqlTransaction transaction, CommandType commandType, string storedProcedureName, List<KeyValuePair<string, object>> inputParamColl, List<KeyValuePair<string, object>> outputParamColl)
        {

            //create a command and prepare it for execution
            NpgsqlCommand cmd = new NpgsqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, storedProcedureName);

            foreach (KeyValuePair<string, object> kvp in inputParamColl)
            {
                NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                sqlParaMeter.IsNullable = true;
                sqlParaMeter.ParameterName = kvp.Key;
                sqlParaMeter.Value = kvp.Value;
                cmd.Parameters.Add(sqlParaMeter);
            }

            foreach (KeyValuePair<string, object> kvp in outputParamColl)
            {
                NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                sqlParaMeter.IsNullable = true;
                sqlParaMeter.ParameterName = kvp.Key;
                sqlParaMeter.Value = kvp.Value;
                sqlParaMeter.Direction = ParameterDirection.InputOutput;
                sqlParaMeter.Size = 256;
                cmd.Parameters.Add(sqlParaMeter);
            }

            cmd.ExecuteNonQuery();
            List<KeyValuePair<int, string>> lstRetValues = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < outputParamColl.Count; i++)
            {
                lstRetValues.Add(new KeyValuePair<int, string>(i, cmd.Parameters[inputParamColl.Count + i].Value.ToString()));
            }
            return lstRetValues;
        }




        /// <summary>
        /// Executes non query with multipal output.
        /// </summary>
        /// <param name="storedProcedureName">Strored procedure name.</param>
        /// <param name="inputParamColl">Accept Key Value collection for parameters.</param>
        /// <param name="outputParamColl">Output Key Value collection for parameters.</param>
        /// <returns>List Key Value collection</returns>
        public List<KeyValuePair<int, string>> ExecuteNonQueryWithMultipleOutput(string storedProcedureName, List<KeyValuePair<string, object>> inputParamColl, List<KeyValuePair<string, object>> outputParamColl)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> kvp in inputParamColl)
                {
                    NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = kvp.Key;
                    sqlParaMeter.Value = kvp.Value;
                    command.Parameters.Add(sqlParaMeter);
                }

                foreach (KeyValuePair<string, object> kvp in outputParamColl)
                {
                    NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = kvp.Key;
                    sqlParaMeter.Value = kvp.Value;
                    sqlParaMeter.Direction = ParameterDirection.InputOutput;
                    sqlParaMeter.Size = 256;
                    command.Parameters.Add(sqlParaMeter);
                }


                conn.Open();
                command.ExecuteNonQuery();
                List<KeyValuePair<int, string>> lstRetValues = new List<KeyValuePair<int, string>>();
                for (int i = 0; i < outputParamColl.Count; i++)
                {
                    lstRetValues.Add(new KeyValuePair<int, string>(i, command.Parameters[inputParamColl.Count + i].Value.ToString()));
                }
                return lstRetValues;
            }
        }







        /// <summary>
        /// Executes non query
        /// </summary>
        /// <param name="transaction">Transact-SQL transaction</param>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text.</param>
        /// <param name="parameterCollection">Output Key Value collection for parameters.</param>
        public void ExecuteNonQuery(NpgsqlTransaction transaction, CommandType commandType, string commandText, List<KeyValuePair<string, object>> parameterCollection)
        {

            //create a command and prepare it for execution
            NpgsqlCommand cmd = new NpgsqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText);

            for (int i = 0; i < parameterCollection.Count; i++)
            {
                NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                sqlParaMeter.IsNullable = true;
                sqlParaMeter.ParameterName = parameterCollection[i].Key;
                sqlParaMeter.Value = parameterCollection[i].Value;
                cmd.Parameters.Add(sqlParaMeter);
            }

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
        }



        /// <summary>
        ///  Executes non query
        /// </summary>
        /// <param name="transaction">Transact-SQL transaction</param>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text.</param>
        /// <param name="parameterCollection">Accept Key Value collection for parameters.</param>
        /// <param name="outParamName">Output parameter.</param>
        /// <returns>ID</returns>
        public int ExecuteNonQuery(NpgsqlTransaction transaction, CommandType commandType, string commandText, List<KeyValuePair<string, object>> parameterCollection, string outParamName)
        {
            //create a command and prepare it for execution
            NpgsqlCommand cmd = new NpgsqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText);

            for (int i = 0; i < parameterCollection.Count; i++)
            {
                NpgsqlParameter sqlParaMeter = new NpgsqlParameter();
                sqlParaMeter.IsNullable = true;
                sqlParaMeter.ParameterName = parameterCollection[i].Key;
                sqlParaMeter.Value = parameterCollection[i].Value;
                cmd.Parameters.Add(sqlParaMeter);
            }
            cmd.Parameters.Add(new NpgsqlParameter(outParamName, SqlDbType.Int));
            cmd.Parameters[outParamName].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            int id = (int)cmd.Parameters[outParamName].Value;

            // detach the Parameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return id;
        }





    }
}

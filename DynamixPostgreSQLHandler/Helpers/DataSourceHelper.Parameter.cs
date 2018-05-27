using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Npgsql;

namespace DynamixPostgreSQLHandler.Helpers
{
    public partial class DataSourceHelper
    {
        /// <summary>
        /// Return out put parametr of given type.
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="command">SQL command.</param>
        /// <param name="outputParameterName">Out put parameter name.</param>
        /// <returns>Object of SqlCommand.</returns>
        public static NpgsqlCommand AddOutPutParametrofGivenType<T>(NpgsqlCommand command, string outputParameterName)
        {
            if (typeof(T) == typeof(int))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(Int16))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(long))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.BigInt));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(DateTime))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.DateTime));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(string))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.NVarChar));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(bool))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Bit));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(decimal))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Decimal));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
                command.Parameters[outputParameterName].Precision = 16;
                command.Parameters[outputParameterName].Scale = 2;
            }
            if (typeof(T) == typeof(float))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Float));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            return command;
        }



        /// <summary>
        /// Return out put parametr of given type.
        /// </summary>
        /// <typeparam name="T">Given type of object.</typeparam>
        /// <param name="command">SQL command.</param>
        /// <param name="outputParameterName">Out put paramerter name.</param>
        ///   <param name="outputParameterValue">Out put paramerter value.</param>
        /// <returns>Object of SqlCommand.</returns>
        public static NpgsqlCommand AddOutPutParametrofGivenType<T>(NpgsqlCommand command, string outputParameterName, object outputParameterValue)
        {

            if (typeof(T) == typeof(int))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(Int16))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Int));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(long))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.BigInt));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(DateTime))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.DateTime));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(string))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.NVarChar));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(bool))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Bit));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(decimal))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Decimal));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
                command.Parameters[outputParameterName].Precision = 16;
                command.Parameters[outputParameterName].Scale = 2;
            }
            if (typeof(T) == typeof(float))
            {
                command.Parameters.Add(new NpgsqlParameter(outputParameterName, SqlDbType.Float));
                command.Parameters[outputParameterName].Direction = ParameterDirection.Output;
            }
            command.Parameters[outputParameterName].Value = outputParameterValue;
            return command;
        }



        /// <summary>
        /// Bulid Collection of List<KeyValuePair<string, string>> for Given object
        /// </summary>
        /// <typeparam name="List">List of Type(string,string)</typeparam>
        /// <param name="paramCollection">List of Type(string,string)</param>
        /// <param name="obj">Object</param>        
        /// <returns> Collection of KeyValuePair<string, string> </returns>
        public List<KeyValuePair<string, string>> BuildParameterCollection(List<KeyValuePair<string, string>> paramCollection, object obj)
        {
            try
            {
                foreach (PropertyInfo objProperty in obj.GetType().GetProperties())
                {
                    if (objProperty.GetValue(obj, null).ToString() != null)
                    {
                        paramCollection.Add(new KeyValuePair<string, string>("@" + objProperty.Name.ToString(), objProperty.GetValue(obj, null).ToString()));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return paramCollection;
        }



        /// <summary>
        /// Bulid Collection of List<KeyValuePair<string, object>> for Given object
        /// </summary>
        /// <typeparam name="List">List of Type(string,object)</typeparam>
        /// <param name="paramCollection">List of Type(string,object)</param>
        /// <param name="obj">Object</param>
        /// <param name="excludeNullValue">Set True To Exclude Properties Having Null Value In The Object From Adding To The Collection</param>
        /// <returns> Collection of KeyValuePair<string, object></returns>
        public List<KeyValuePair<string, object>> BuildParameterCollection(List<KeyValuePair<string, object>> paramCollection, object obj, bool excludeNullValue)
        {
            try
            {
                if (excludeNullValue)
                {
                    foreach (PropertyInfo objProperty in obj.GetType().GetProperties())
                    {
                        if (objProperty.GetValue(obj, null) != null)
                        {
                            paramCollection.Add(new KeyValuePair<string, object>("@" + objProperty.Name.ToString(), objProperty.GetValue(obj, null)));
                        }
                    }
                }
                else
                {
                    foreach (PropertyInfo objProperty in obj.GetType().GetProperties())
                    {
                        paramCollection.Add(new KeyValuePair<string, object>("@" + objProperty.Name.ToString(), objProperty.GetValue(obj, null)));
                    }
                    return paramCollection;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return paramCollection;
        }



    }
}

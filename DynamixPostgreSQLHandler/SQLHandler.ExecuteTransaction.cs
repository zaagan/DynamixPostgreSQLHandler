using System;
using System.Collections.Generic;
using System.Data;
using DynamixPostgreSQLHandler.Helpers;
using Microsoft.VisualBasic;
using Npgsql;

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {

        /// <summary>
        /// Return  base class for a transaction.
        /// </summary>
        /// <returns>Object of SqlTransaction</returns>
        public NpgsqlTransaction GetTransaction()
        {
            NpgsqlConnection Conn = new NpgsqlConnection(ConnectionString);
            Conn.Open();
            NpgsqlTransaction transaction = Conn.BeginTransaction();
            return transaction;
        }


        /// <summary>
        ///Roll back SQL transaction.
        /// </summary>
        /// <param name="transaction">transaction</param>
        public void RollbackTransaction(NpgsqlTransaction transaction)
        {
            try
            {
                transaction.Rollback();
            }
            finally
            {
                if (transaction != null && transaction.Connection != null)
                {
                    transaction.Connection.Close();
                }
            }
        }


        /// <summary>
        /// Commit transaction on database.
        /// </summary>
        /// <param name="transaction"></param>
        public void CommitTransaction(NpgsqlTransaction transaction)
        {
            try
            {
                transaction.Commit();
            }
            finally
            {
                if (transaction != null && transaction.Connection != null)
                {
                    transaction.Connection.Close();
                }
            }
        }


        /// <summary>
        /// Prepare command for execute.
        /// </summary>
        /// <param name="command">Sql Command.</param>
        /// <param name="connection">connection</param>
        /// <param name="transaction">Transact-SQL transaction</param>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text.</param>
        public void PrepareCommand(NpgsqlCommand command, NpgsqlConnection connection, NpgsqlTransaction transaction, CommandType commandType, string commandText)
        {
            //if the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            //associate the connection with the command
            command.Connection = connection;
            command.Transaction = transaction;
            command.CommandType = commandType;
            command.CommandText = commandText;
            return;
        }


        /// <summary>
        /// Execute Transaction
        /// </summary>
        /// <param name="trans">Transact-SQL transaction.</param>
        /// <param name="sqlScript">SQL Script</param>
        private void ExecuteTransaction(NpgsqlTransaction trans, string sqlScript)
        {
            NpgsqlConnection connection = trans.Connection;
            NpgsqlCommand command = new NpgsqlCommand(sqlScript, trans.Connection);
            command.Transaction = trans;
            command.CommandTimeout = 0;
            command.ExecuteNonQuery();
        }




    }
}

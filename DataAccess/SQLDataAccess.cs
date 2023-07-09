using Dapper;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace DataAccess
{
    public class SQLDataAccess
    {
        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
                return rows;
            }
        }

        public IEnumerable<T> LoadRecord<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<T> record = connection.Query<T>(sqlStatement, parameters);

                return record;
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters);
            }
        }

        public void BulkSaveData<T>(string sqlStatement, List<T> itemsToSave, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute(sqlStatement, itemsToSave, transaction: transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }
        }
    }
}

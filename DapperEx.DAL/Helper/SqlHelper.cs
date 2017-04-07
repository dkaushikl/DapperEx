using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using DapperExtensions;
using Dapper;
using System.Data;

namespace DapperEx.DAL.Helper
{
    public static class SqlHelper
    {
        public static bool Insert<T>(T parameter, string connectionString) where T : class
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Insert(parameter);
                sqlConnection.Close();
                return true;
            }
        }

        public static int InsertWithReturnId<T>(T parameter, string connectionString) where T : class
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var recordId = sqlConnection.Insert(parameter);
                sqlConnection.Close();
                return recordId;
            }
        }

        public static bool Update<T>(T parameter, string connectionString) where T : class
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Update(parameter);
                sqlConnection.Close();
                return true;
            }
        }

        public static IList<T> GetAll<T>(string connectionString) where T : class
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var result = sqlConnection.GetList<T>();
                sqlConnection.Close();
                return result.ToList();
            }
        }

        public static T Find<T>(PredicateGroup predicate, string connectionString) where T : class
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var result = sqlConnection.GetList<T>(predicate).FirstOrDefault();
                sqlConnection.Close();
                return result;
            }
        }

        public static bool Delete<T>(PredicateGroup predicate, string connectionString) where T : class
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Delete<T>(predicate);
                sqlConnection.Close();
                return true;
            }
        }

        public static IEnumerable<T> QuerySp<T>(string storedProcedure, dynamic param = null,
            dynamic outParam = null, SqlTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, string connectionString = null) where T : class
        {
            if (connectionString != null)
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var output = connection.Query<T>(storedProcedure, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: commandTimeout, commandType: CommandType.StoredProcedure);
                return output;
            }
            return null;
        }

        private static void CombineParameters(ref dynamic param, dynamic outParam = null)
        {
            if (outParam != null)
            {
                if (param != null)
                {
                    param = new DynamicParameters(param);
                    ((DynamicParameters)param).AddDynamicParams(outParam);
                }
                else
                {
                    param = outParam;
                }
            }
        }

        private static int ConnectionTimeout { get; set; }

        private static int GetTimeout(int? commandTimeout = null)
        {
            if (commandTimeout.HasValue)
                return commandTimeout.Value;

            return ConnectionTimeout;
        }
    }
}

using Dapper;
using DapperEx.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DapperEx.DAL
{
    public class UserDal
    {
        public int InsertUser(Entity.User user, string connectionString)
        {
            int recordId = SqlHelper.InsertWithReturnId(user, connectionString);
            return recordId;
        }

        public IList<Entity.User> GetAllUser(string connectionString)
        {
            return SqlHelper.GetAll<Entity.User>(connectionString);
        }

        public IEnumerable<Entity.User> GetAllUser(string spName, string connectionString)
        {
            var user = SqlHelper.QuerySp<Entity.User>(spName, null, null, null, false, 0, connectionString);
            return user;
        }

        public Entity.User UpdateUser(Entity.User user, string connectionString)
        {
            throw new NotImplementedException();
        }

        public Entity.User GetByUserId(string spName, DynamicParameters userId, string connectionString)
        {
            var user = SqlHelper.QuerySp<Entity.User>(spName, userId, null, null, false, 0, connectionString);
            return (Entity.User)user.FirstOrDefault();
        }

        public Entity.User GetUser(int userId, string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}

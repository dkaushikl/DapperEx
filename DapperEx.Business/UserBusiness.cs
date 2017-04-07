using Dapper;
using DapperEx.DAL;
using System.Collections.Generic;
using System.Data;

namespace DapperEx.Business
{
    public class UserBusiness
    {
        public readonly UserDal UserDal = new UserDal();
        public int InsertUser(Entity.User user, string connectionString)
        {
            var recordId = UserDal.InsertUser(user, connectionString);
            return recordId;
        }

        public Entity.User UpdateUser(Entity.User user, string connectionString)
        {
            return UserDal.UpdateUser(user, connectionString);
        }

        public IList<Entity.User> GetAllUser(string connectionString)
        {
            return UserDal.GetAllUser(connectionString);
        }

        public IEnumerable<Entity.User> GetAllUser(string spName, string connectionString)
        {
            return UserDal.GetAllUser(spName, connectionString);
        }

        public Entity.User  GetUser(int userId, string connectionString)
        {
            return UserDal.GetUser(userId, connectionString);
        }

        public Entity.User  GetByUserId(string spName, string userId, string connectionString)
        {
            var p = new DynamicParameters();
            p.Add("@UserID", userId, DbType.String, null, 100);

            return UserDal.GetByUserId(spName, p, connectionString);
        }
    }
}

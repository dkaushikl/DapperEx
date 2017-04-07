using System;

namespace DapperEx.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Userid { get; set; }
        public string UserPswd { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public DateTime PswdExpire { get; set; }
    }
}

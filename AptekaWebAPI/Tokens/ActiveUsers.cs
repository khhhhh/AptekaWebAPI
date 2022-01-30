using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Tokens
{
    public class ActiveUsers
    {
        private static readonly ISet<LoginedUser> AllActiveUsers = new HashSet<LoginedUser>();

        public void addUser(LoginedUser user)
        {
            AllActiveUsers.Add(user);
        }

        public IEnumerable<LoginedUser> GetAllLoginedUsers()
        {
            return AllActiveUsers;
        }
    }
}

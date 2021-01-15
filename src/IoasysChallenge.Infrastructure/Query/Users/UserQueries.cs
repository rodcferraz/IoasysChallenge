using System;
using System.Collections.Generic;
using System.Linq;
using IoasysChallenge.ApplicationCore.Entity;
using System.Text;

namespace IoasysChallenge.Infrastructure.Query.Users
{
    public static class UserQueries
    {
        public static IQueryable<User> UsersActive (this IQueryable<User> users)
        {
            return users.Where(u => u.IsDeleted == null && u.Role.Equals("User"));
        }
    }
}

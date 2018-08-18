using AppBlogRest.Models.Entities;
using SQLite;
using System;
using System.Linq.Expressions;

namespace AppBlogRest.Models.Repositories
{
    public class UserRepository : Repository<User>
    {
        public User Find(int Id)
        {
            return conexaoSQLite.Table<User>().FirstOrDefault(p => p.Id == Id);
        }

        public TableQuery<User> Get(Expression<Func<User, bool>> filter = null)
        {
            return conexaoSQLite.Table<User>().Where(filter);
        }

        public TableQuery<User> GetAll()
        {
            return conexaoSQLite.Table<User>().OrderByDescending(p => p.Id);
        }
    }
}

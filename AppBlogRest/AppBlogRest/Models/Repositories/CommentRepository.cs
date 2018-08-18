using AppBlogRest.Models.Entities;
using SQLite;
using System;
using System.Linq.Expressions;

namespace AppBlogRest.Models.Repositories
{
    public class CommentRepository : Repository<Comment>
    {
        public Comment Find(int Id)
        {
            return conexaoSQLite.Table<Comment>().FirstOrDefault(p => p.Id == Id);
        }

        public TableQuery<Comment> Get(Expression<Func<Comment, bool>> filter = null)
        {
            return conexaoSQLite.Table<Comment>().Where(filter);
        }

        public TableQuery<Comment> GetAll()
        {
            return conexaoSQLite.Table<Comment>().OrderByDescending(p => p.Id);
        }
    }
}
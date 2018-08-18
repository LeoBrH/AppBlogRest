using AppBlogRest.Models.Entities;
using SQLite;
using System;
using System.Linq.Expressions;

namespace AppBlogRest.Models.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public Post Find(int Id)
        {
            return conexaoSQLite.Table<Post>().FirstOrDefault(p => p.Id == Id);
        }

        public TableQuery<Post> Get(Expression<Func<Post, bool>> filter = null)
        {
            return conexaoSQLite.Table<Post>().Where(filter);
        } 

        public TableQuery<Post> GetAll()
        {
            return conexaoSQLite.Table<Post>().OrderByDescending(p => p.Id);
        }
    }
}
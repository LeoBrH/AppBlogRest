using AppBlogRest.Models.Repositories.Interface;
using SQLite;
using System;
using System.IO;

namespace AppBlogRest.Models.Repositories
{
    public class Repository<T> : /*IDisposable,*/ IRepository<T> where T : class
    {
        protected SQLiteConnection conexaoSQLite;

        public Repository()
        {
            conexaoSQLite = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbBlogRest.db3"));
            conexaoSQLite.CreateTable<T>();
        }

        public void Add(T entity)
        {
            conexaoSQLite.Insert(entity);
        }

        public void Update(T entity)
        {
            conexaoSQLite.Update(entity);
        }

        public void Delete(T entity)
        {
            conexaoSQLite.Delete(entity);
        }

        /*public T Find(int Id)
        {
            return conexaoSQLite.Find<T>(Id);
        }

        public async Task<TableQuery<T>> Get(Expression<Func<T, bool>> filter)
        {
            return conexaoSQLite.Table<T>().Where(filter);
        }*/

        /*public void Dispose()
        {
            conexaoSQLite.Dispose();
        }*/
    }
}

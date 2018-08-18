namespace AppBlogRest.Models.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        /*T Find(int Id);

        Task<TableQuery<T>> Get(Expression<Func<T, bool>> filter = null);*/
    }
}

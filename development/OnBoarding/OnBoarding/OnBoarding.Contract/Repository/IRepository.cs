namespace OnBoarding.Contract.Repository
{
    using System;
    using System.Linq;

    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : class;
        T Get<T>(object Id) where T : class;
        T Save<T>(T entity) where T : class;
        T Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
    
}

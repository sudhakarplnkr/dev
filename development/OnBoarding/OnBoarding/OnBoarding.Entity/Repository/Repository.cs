namespace OnBoarding.EntityContext
{
    using Contract.Repository;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class Repository : IRepository
    {
        private readonly DbContext context;
        private DbContextTransaction transaction;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            transaction = this.context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Set<T>().Remove(entity);
        }

        public T Get<T>(object Id) where T : class
        {
           return this.context.Set<T>().Find(Id);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return this.context.Set<T>().AsQueryable<T>();
        }

        public T Save<T>(T entity) where T : class
        {
            return this.context.Set<T>().Add(entity);
        }

        public T Update<T>(T entity) where T : class
        {
            DbEntityEntry<T> dbEntityEntry = this.context.Entry<T>(entity);
            this.context.Set<T>().Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
            return entity;
        }
    }
}

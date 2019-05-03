namespace OnBoarding.EntityContext
{
    using Contract.Repository;
    using System.Data.Entity;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}

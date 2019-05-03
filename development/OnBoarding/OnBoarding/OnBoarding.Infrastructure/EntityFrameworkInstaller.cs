namespace OnBoarding.Infrastructure
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Contract.Repository;
    using OnBoarding.EntityContext;
    using System.Data.Entity;

    public static class EntityFrameworkInstaller
    {
        public static void Install(IWindsorContainer container)
        {
            const string ConnectionString = "OnBoarding";

            container.Register(Component.For<DbContext>().UsingFactoryMethod(m => new OnBoardingContext(ConnectionString)).LifestylePerWebRequest());

            container.Register(Component.For<IRepository>().ImplementedBy<Repository>().LifestylePerWebRequest());

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestylePerWebRequest());
        }
    }
}

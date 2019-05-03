namespace OnBoarding.EntityContext
{
    using System.Data.Entity.Infrastructure;

    public class DbContextFactory : IDbContextFactory<OnBoardingContext>
    {
        public OnBoardingContext Create()
        {
            return new OnBoardingContext("OnBoarding");
        }
    }
}

using System.Data.Entity.Migrations;
using System.Web.Http;
using OnBoarding.EntityContext.Migrations;

namespace OnBoardingWEB.Controllers
{
    public class UpdateMigrationController : ApiController
    {
        [HttpGet]
        public void Get(bool id)
        {
            var configuration = new Configuration(id);
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

    }
}

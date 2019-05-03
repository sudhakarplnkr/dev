using MediatR;
using OnBoarding.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly IMediator mediatr;

        public ProjectController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public IList<Project> Get()
        {
            var response = this.mediatr.Send(new GetProjectRequest());

            return response.Result;
        }
    }
}
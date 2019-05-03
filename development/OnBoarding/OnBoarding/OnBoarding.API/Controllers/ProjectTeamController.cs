using MediatR;
using OnBoarding.Contract;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class ProjectTeamController : ApiController
    {

        private readonly IMediator mediator;

        public ProjectTeamController(IMediator objMediator)
        {
            mediator = objMediator;
        }

        [HttpGet]
        public IList<Team> GetTeamList(Guid projectId)
        {
            var response = mediator.Send(new GetTeamRequest(projectId));

            return response.Result;
        }
    }
}
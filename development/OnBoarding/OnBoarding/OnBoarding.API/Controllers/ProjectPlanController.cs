using MediatR;
using OnBoarding.Contract;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class ProjectPlanController : ApiController
    {
        private readonly IMediator mediatr;

        public ProjectPlanController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public IList<ProjectPlan> Query(Guid ProjectId)
        {
            var response = this.mediatr.Send(new GetProjectPlanRequest(ProjectId));

            return response.Result;
        }

        [HttpPost]
        public ProjectPlan Post(CreateProjectPlan request)
        {
            var response = this.mediatr.Send(new CreateProjectPlanRequest(request));

            return response.Result;
        }

        [HttpPut]
        public ProjectPlan Put(Guid id, ProcessUpdateProjectPlan request)
        {
            var response = this.mediatr.Send(new ProcessUpdateProjectPlanRequest(request));
            
            return response.Result;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            this.mediatr.Send(new DeleteProjectPlanRequest(id));
        }
    }
}
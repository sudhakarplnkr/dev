using MediatR;
using OnBoarding.Contract;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class ProjectGroupController : ApiController
    {
        private readonly IMediator mediatr;

        public ProjectGroupController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public IList<ProjectGroup> Query(Guid ProjectId)
        {
            var response = this.mediatr.Send(new GetProjectGroupByProjectRequest(ProjectId));

            return response.Result;
        }

        [HttpPost]
        public ProjectGroup Post([FromBody] ProcessCreateProjectGroup request)
        {
            var response = this.mediatr.Send(new ProcessCreateProjectGroupRequest(request));

            return response.Result;
        }

        [HttpPut]
        public ProjectGroup Put(Guid id, [FromBody] ProcessUpdateProjectGroup request)
        {
            var response = this.mediatr.Send(new ProcessUpdateProjectGroupRequest(request));
            
            return response.Result;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            this.mediatr.Send(new DeleteProjectGroupRequest(id));
        }
    }
}
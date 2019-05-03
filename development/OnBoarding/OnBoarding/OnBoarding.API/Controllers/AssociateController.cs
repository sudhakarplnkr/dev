using MediatR;
using OnBoarding.Contract;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class AssociateController : ApiController
    {
        private readonly IMediator mediatr;

        public AssociateController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public IList<Associate> Get()
        {
            var response = this.mediatr.Send(new GetAssociateRequest());

            return response.Result;
        }

        [HttpGet]
        [Route("api/Associate/Query")]
        public IList<AssociateProjectGroup> Query(Guid projectId, Guid? projectGroupId)
        {
            var response = this.mediatr.Send(new GetAssociateByProjectGroupRequest(projectId, projectGroupId));

            return response.Result;
        }
    }
}
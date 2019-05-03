using MediatR;
using OnBoarding.Contract;
using OnBoarding.WebAPI.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class AssociatePlanController : ApiController
    {
        private readonly IMediator mediator;

        public AssociatePlanController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("api/AssociatePlan/query")]
        public IList<AssociatePlan> query()
        {
            string LoginID = CommonHelper.GetLoginId(HttpContext.Current);
            var Response = this.mediator.Send(new GetAssociatePlanRequest(LoginID));

            return Response.Result;
        }

        [HttpGet]
        public IList<AssociatePlan> GetAssociatePlanStatus(Guid projectGroupPlanId)
        {
            var Response = mediator.Send(new GetAssociatePlanByProjectGroupRequest(projectGroupPlanId));

            return Response.Result;
        }

        [HttpPost]
        public byte[] Upload(Guid id)
        {
            byte[] fileData = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }
                this.mediator.Send(new UpdateAssociatePlanRequest(new UpdateAssociatePlan { Id = id, Status = true, CompletionDate = DateTime.Now }, fileData));
            }

            return fileData;
        }

        [HttpPut]
        public AssociatePlan Put(Guid id, [FromBody] UpdateAssociatePlan request)
        {
            var Response = this.mediator.Send(new UpdateAssociatePlanRequest(request, null));

            return Response.Result;
        }
    }
}
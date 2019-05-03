using MediatR;
using OnBoarding.Contract;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class AssociateDetailsController : ApiController
    {
        private readonly IMediator mediator;
        public AssociateDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("api/Associate/Details")]
        public Response<IList<AssociateDetails>> Get(PageRequest pageRequest)
        {   
            var response = this.mediator.Send(new GetAssociateDetailsByAssociateRequest(pageRequest));
            return response.Result;
        }

        [HttpPost]
        public AssociateDetails Post([FromBody] AssociateDetails request)
        {
            var response = this.mediator.Send(new CreateAssociateDetailsRequest(request));

            return response.Result;
        }

        [HttpPut]
        public UpdateAssociateDetails Put(UpdateAssociateDetails request)
        {
            var response = this.mediator.Send(new UpdateAssociateDetailsRequest(request));

            return response.Result;
        }

        [HttpDelete]
        public DeleteAssociateDetails Delate(Guid Id)
        {
            var response = mediator.Send(new DeleteAssociateDetailsRequest(Id));

            return response.Result;
        }
    }
}
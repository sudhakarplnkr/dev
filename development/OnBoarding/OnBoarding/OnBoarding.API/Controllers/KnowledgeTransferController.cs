using MediatR;
using OnBoarding.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class KnowledgeTransferController : ApiController
    {
        private readonly IMediator mediatr;

        public KnowledgeTransferController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public IList<KnowledgeTransfer> Get()
        {
            var response = this.mediatr.Send(new GetKnowledgeTransferRequest());

            return response.Result;
        }
    }
}
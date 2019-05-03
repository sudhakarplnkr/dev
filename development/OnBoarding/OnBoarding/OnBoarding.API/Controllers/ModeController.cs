using MediatR;
using OnBoarding.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class ModeController : ApiController
    {
        private readonly IMediator mediatr;

        public ModeController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public IList<Mode> Get()
        {
            var response = this.mediatr.Send(new GetModeRequest());

            return response.Result;
        }
    }
}
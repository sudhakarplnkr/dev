using MediatR;
using OnBoarding.Contract;
using OnBoarding.WebAPI.Common;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class UserRoleController : ApiController
    {
        private readonly IMediator mediator;
        public UserRoleController(IMediator _mediator)
        {
            this.mediator = _mediator;

        }
        [HttpGet]
        public IList<UserRole> Get()
        {
            string loginId = CommonHelper.GetLoginId(HttpContext.Current);
            var response = this.mediator.Send(new GetUserRolesByUserIdRequest(loginId));
            
            return response.Result;
        }
    }
}
using MediatR;
using OnBoarding.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IMediator mediatr;

        public RoleController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public IList<Role> Get()
        {
            var response = this.mediatr.Send(new GetRoleRequest());
            
            return response.Result;
        }
    }
}
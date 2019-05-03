using MediatR;
using OnBoarding.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class AccountRoleController : ApiController
    {//
        private readonly IMediator mediator;

        public AccountRoleController(IMediator objMediator)
        {
            mediator = objMediator;
        }

        [HttpGet]
        public IList<AccountRole> GetRole()
        {
            var response = mediator.Send(new GetAccountRoleRequest());            
            return response.Result;
        }
    }
}
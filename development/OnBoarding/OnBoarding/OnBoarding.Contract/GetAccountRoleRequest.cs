namespace OnBoarding.Contract
{
    using MediatR;
    using System.Collections.Generic;
    public class GetAccountRoleRequest : IRequest<IList<AccountRole>>
    {
        public GetAccountRoleRequest()
        {

        }
    }
}

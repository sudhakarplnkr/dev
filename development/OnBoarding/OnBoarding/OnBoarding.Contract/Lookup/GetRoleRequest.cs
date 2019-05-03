namespace OnBoarding.Contract
{
    using MediatR;
    using System.Collections.Generic;

    public class GetRoleRequest : IRequest<IList<Role>>
    {
    }
}

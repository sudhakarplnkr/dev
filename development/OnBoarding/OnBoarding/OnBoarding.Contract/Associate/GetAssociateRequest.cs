namespace OnBoarding.Contract
{
    using MediatR;
    using System.Collections.Generic;

    public class GetAssociateRequest : IRequest<IList<Associate>>
    {
    }
}

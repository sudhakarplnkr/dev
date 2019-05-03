namespace OnBoarding.Contract
{
    using MediatR;
    using System.Collections.Generic;

    public class GetModeRequest : IRequest<IList<Mode>>
    {
    }
}

namespace OnBoarding.Contract
{
    using MediatR;
    using System.Collections.Generic;

    public class GetDashboardRequest : IRequest<IList<Dashboard>>
    {
    }
}

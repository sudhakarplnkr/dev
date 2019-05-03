namespace OnBoarding.Contract
{
    using MediatR;
    using System.Collections.Generic;

    public class GetProjectRequest : IRequest<IList<Project>>
    {
    }
}

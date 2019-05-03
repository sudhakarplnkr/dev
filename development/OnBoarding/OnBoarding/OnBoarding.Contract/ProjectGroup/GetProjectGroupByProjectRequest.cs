namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetProjectGroupByProjectRequest : IRequest<IList<ProjectGroup>>
    {
        public GetProjectGroupByProjectRequest(Guid projectId)
        {
            this.ProjectId = projectId;
        }

        public Guid ProjectId { get; private set; }
    }
}

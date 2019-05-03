namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetProjectGroupPlanWithStatusRequest : IRequest<IList<ProjectGroupPlanWithStatus>>
    {
        public GetProjectGroupPlanWithStatusRequest(Guid projectGroupId)
        {
            this.ProjectGroupId = projectGroupId;
        }

        public Guid ProjectGroupId { get; private set; }
    }
}

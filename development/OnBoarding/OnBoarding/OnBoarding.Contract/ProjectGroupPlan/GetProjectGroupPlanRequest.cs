namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetProjectGroupPlanRequest : IRequest<IList<ProjectGroupPlan>>
    {
        public GetProjectGroupPlanRequest(Guid projectGroupId)
        {
            this.ProjectGroupId = projectGroupId;
        }

        public Guid ProjectGroupId { get; private set; }
    }
}

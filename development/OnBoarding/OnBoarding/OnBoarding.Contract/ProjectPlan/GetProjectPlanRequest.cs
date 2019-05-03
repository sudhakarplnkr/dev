namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetProjectPlanRequest : IRequest<IList<ProjectPlan>>
    {
        public GetProjectPlanRequest(Guid projectId)
        {
            this.ProjectId = projectId;
        }

        public Guid ProjectId { get; private set; } 

    }
}

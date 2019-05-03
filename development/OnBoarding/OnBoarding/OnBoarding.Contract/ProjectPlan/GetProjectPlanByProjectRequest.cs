namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetProjectPlanByProjectRequest : IRequest<IList<ProjectPlan>>
    {
        public GetProjectPlanByProjectRequest(Guid projectId, IList<Guid> roles)
        {
            this.ProjectId = projectId;
            this.Roles = roles;
        }
         
        public Guid ProjectId { get; private set; }

        public IList<Guid> Roles { get; private set; } 
    }
}

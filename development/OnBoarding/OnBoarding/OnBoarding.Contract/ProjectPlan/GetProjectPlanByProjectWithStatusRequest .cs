namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetProjectPlanByProjectWithStatusRequest : IRequest<IList<ProjectPlan>>
    {
        public GetProjectPlanByProjectWithStatusRequest(Guid roleId)
        {
            this.RoleId = roleId;
        }

        public Guid RoleId { get; private set; } 

    }
}

namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetProjectGroupPlanByRolesRequest : IRequest<IList<ProjectGroupPlan>>
    {
        public GetProjectGroupPlanByRolesRequest(Guid projectGroupId, IList<Guid> roleIds)
        {
            this.ProjectGroupId = projectGroupId;

            this.RoleIds = roleIds;
        }

        public IList<Guid> RoleIds { get; private set; }

        public Guid ProjectGroupId { get; private set; }
    }
}

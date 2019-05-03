namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class DeleteAssociatePlanByProjectGroupPlanRequest : IRequest<DeleteAssociatePlanByProjectGroupPlanResponse>
    {
        public DeleteAssociatePlanByProjectGroupPlanRequest(Guid projectGroupPlanId, IList<Guid> roleIds)
        {
            this.ProjectGroupPlanId = projectGroupPlanId;
            this.RoleIds = roleIds;
        }

        public Guid ProjectGroupPlanId { get; private set; }

        public IList<Guid> RoleIds { get; private set; }
    }
}

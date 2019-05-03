namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    public class GetAssociateGroupByProjectGroupRequest : IRequest<IList<AssociateGroup>>
    {
        public GetAssociateGroupByProjectGroupRequest(Guid projectGroupId, Guid projectGroupPlanId)
        {            
            this.ProjectGroupId = projectGroupId;
            this.ProjectGroupPlanId = projectGroupPlanId;
        }

        public Guid ProjectGroupId { get; set; }

        public Guid ProjectGroupPlanId { get; set; }

        public IList<Guid> RoleIds { get; set; }
    }
}

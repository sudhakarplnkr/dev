namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;
    using MediatR;

    public  class GetAssociatePlanByProjectGroupRequest : IRequest<IList<AssociatePlan>>
    {
        public GetAssociatePlanByProjectGroupRequest(Guid projectGroupPlanId)
        {
            ProjectGroupPlanId = projectGroupPlanId;
        }
        public Guid ProjectGroupPlanId { get; private set; }
    }
}

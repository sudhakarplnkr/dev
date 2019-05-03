namespace OnBoarding.Contract
{
    using MediatR;
    using System;

    public class DeleteProjectGroupPlanRequest : IRequest<DeleteProjectGroupPlanResponse>
    {
        public DeleteProjectGroupPlanRequest(Guid projectGroupPlanId)
        {
            this.ProjectGroupPlanId = projectGroupPlanId;
        }

        public Guid ProjectGroupPlanId { get; private set; }
    }
}

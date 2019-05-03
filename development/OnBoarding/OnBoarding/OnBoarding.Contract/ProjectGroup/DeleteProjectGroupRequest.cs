namespace OnBoarding.Contract
{
    using MediatR;
    using System;

    public class DeleteProjectGroupRequest : IRequest<DeleteProjectGroupResponse>
    {
        public DeleteProjectGroupRequest(Guid projectGroupId)
        {
            this.ProjectGroupId = projectGroupId;
        }

        public Guid ProjectGroupId { get; private set; }
    }
}

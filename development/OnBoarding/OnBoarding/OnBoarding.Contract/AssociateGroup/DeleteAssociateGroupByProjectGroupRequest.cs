namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class DeleteAssociateGroupByProjectGroupRequest : IRequest<DeleteAssociateGroupByProjectGroupResponse>
    {
        public DeleteAssociateGroupByProjectGroupRequest(Guid projectGroupId, IList<Guid> associateIds)
        {
            this.ProjectGroupId = projectGroupId;
            this.AssociateIds = associateIds;
        }

        public Guid ProjectGroupId { get; private set; }

        public IList<Guid> AssociateIds { get; private set; }
    }
}

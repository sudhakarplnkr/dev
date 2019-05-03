namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    public class GetAssociateByProjectGroupRequest : IRequest<IList<AssociateProjectGroup>>
    {
        public GetAssociateByProjectGroupRequest(Guid projectId, Guid? projectGroupId)
        {
            this.ProjectId = projectId;
            this.ProjectGroupId = projectGroupId;
        }
        public Guid ProjectId { get; set; }
        public Guid? ProjectGroupId { get; set; }
    }
}

namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    public class GetRolesByProjectGroupRequest : IRequest<IList<Guid>>
    {
        public GetRolesByProjectGroupRequest(Guid projectGroupId, IList<Guid> roleIds)
        {
            this.RoleIds = roleIds;
            this.ProjectGroupId = projectGroupId;
        }

        public Guid ProjectGroupId { get; set; }

        public IList<Guid> RoleIds { get; set; }
    }
}

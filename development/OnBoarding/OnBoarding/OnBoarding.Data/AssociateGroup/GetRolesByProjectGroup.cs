namespace OnBoarding.Data
{
    using System.Linq;
    using MediatR;
    using Contract;
    using Contract.Repository;
    using System;
    using System.Collections.Generic;

    public class GetRolesByProjectGroup : IRequestHandler<GetRolesByProjectGroupRequest, IList<Guid>>
    {
        public readonly IRepository repository;
        public GetRolesByProjectGroup(IRepository repository)
        {
            this.repository = repository;
        }
        public IList<Guid> Handle(GetRolesByProjectGroupRequest query)
        {
            var roles = this.repository.Query<Entities.AssociateGroup>().Where(i =>
            query.RoleIds.Contains(i.Associate.RoleId) && i.ProjectGroupId == query.ProjectGroupId).Select(i => i.Associate.RoleId).Distinct().ToList();            

            return roles;
        }
    }
}

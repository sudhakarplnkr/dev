namespace OnBoarding.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediatR;
    using Contract;
    using Contract.Repository;
    public class GetAssociateByProjectGroup : IRequestHandler<GetAssociateByProjectGroupRequest, IList<Contract.AssociateProjectGroup>>
    {
        public readonly IRepository repository;
        public GetAssociateByProjectGroup(IRepository repository)
        {
            this.repository = repository;
        }
        public IList<Contract.AssociateProjectGroup> Handle(GetAssociateByProjectGroupRequest query)
        {
            var data = (from associate in this.repository.Query<Entities.Associate>()
                        join associateGroup in this.repository.Query<Entities.AssociateGroup>()
                        on new {Id = associate.Id, ProjectGroupId = query.ProjectGroupId } equals new { Id = associateGroup.AssociateId, ProjectGroupId = (Guid?)associateGroup.ProjectGroupId }
                        into associateGroupTemp from associateGroup in associateGroupTemp.DefaultIfEmpty()
                        where associate.ProjectId == query.ProjectId && associate.Role.Name != RoleConstant.Other
                        && associate.Active == true
                        select new AssociateProjectGroup
                        {
                            Id = associate.Id,
                            AssociateGroupId = associateGroup.Equals(null) ? null : (Guid?)associateGroup.Id,
                            Name = associate.Name,
                            Code = associate.Code,
                            RoleId = associate.RoleId,
                            IsGroup = !associateGroup.Equals(null)
                         }).ToList();            

            return data;
        }
    }
}

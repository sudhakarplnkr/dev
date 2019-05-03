namespace OnBoarding.Data
{
    using System.Linq;
    using MediatR;
    using Contract;
    using Contract.Repository;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using System;

    public class GetAssociateGroupByProjectGroup : IRequestHandler<GetAssociateGroupByProjectGroupRequest, IList<Contract.AssociateGroup>>
    {
        public readonly IRepository repository;
        private readonly IMediator mediatr;
        public GetAssociateGroupByProjectGroup(IRepository repository, IMediator mediatr)
        {
            this.repository = repository;
            this.mediatr = mediatr;
        }
        public IList<Contract.AssociateGroup> Handle(GetAssociateGroupByProjectGroupRequest query)
        {
            var associateGroups = this.repository.Query<Entities.AssociateGroup>().Where(i => i.ProjectGroupId == query.ProjectGroupId && !i.AssociatePlan.Any(l => l.ProjectGroupPlanId == query.ProjectGroupPlanId));

            
                associateGroups = associateGroups.Where(i => (query.RoleIds.Contains(i.Associate.RoleId)));
            

            return associateGroups.ProjectTo<Contract.AssociateGroup>().ToList();
        }

        private Guid GetCommonRoleId()
        {
            var response = this.mediatr.Send(new GetRoleRequest());

            //if (response.IsFaulted)
            //{
            //    return null;
            //}

            return response.Result.Single(i => i.Code == RoleConstant.Common).Id;
        }
    }
}

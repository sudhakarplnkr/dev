namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class GetProjectGroupPlanByRoles : IRequestHandler<GetProjectGroupPlanByRolesRequest, IList<Contract.ProjectGroupPlan>>
    {
        private readonly IRepository repository;
        public GetProjectGroupPlanByRoles(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Contract.ProjectGroupPlan> Handle(GetProjectGroupPlanByRolesRequest query)
        {
            return this.repository.Query<Entity.ProjectGroupPlan>().Where(i => i.ProjectGroupId == query.ProjectGroupId && i.Active).ProjectTo<Contract.ProjectGroupPlan>().ToList();
        }
    }
}

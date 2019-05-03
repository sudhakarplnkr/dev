namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class GetProjectGroupPlanWithStatus : IRequestHandler<GetProjectGroupPlanWithStatusRequest, IList<Contract.ProjectGroupPlanWithStatus>>
    {
        private readonly IRepository repository;
        public GetProjectGroupPlanWithStatus(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Contract.ProjectGroupPlanWithStatus> Handle(GetProjectGroupPlanWithStatusRequest query)
        {
            return this.repository.Query<Entity.ProjectGroupPlan>().Where(i => i.ProjectGroupId == query.ProjectGroupId && i.Active).OrderBy(i=>i.Week).ThenBy(i=>i.Day).ProjectTo<Contract.ProjectGroupPlanWithStatus>().ToList();
        }
    }
}

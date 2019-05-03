namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class GetProjectGroupPlan : IRequestHandler<GetProjectGroupPlanRequest, IList<Contract.ProjectGroupPlan>>
    {
        private readonly IRepository repository;
        public GetProjectGroupPlan(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Contract.ProjectGroupPlan> Handle(GetProjectGroupPlanRequest query)
        {
            var result= this.repository.Query<Entity.ProjectGroupPlan>().Where(i => i.ProjectGroupId == query.ProjectGroupId && i.Active).ProjectTo<Contract.ProjectGroupPlan>().ToList();

            return result;
        }
    }
}

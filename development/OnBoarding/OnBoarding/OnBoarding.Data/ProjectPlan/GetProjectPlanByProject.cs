namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class GetProjectPlanByProject : IRequestHandler<GetProjectPlanByProjectRequest, IList<ProjectPlan>>
    {
        private readonly IRepository repository;
        public GetProjectPlanByProject(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ProjectPlan> Handle(GetProjectPlanByProjectRequest query)
        {
            return this.repository.Query<Entity.ProjectPlan>().Where(i => i.ProjectId == query.ProjectId && i.Active).ProjectTo<ProjectPlan>().ToList();      

        }

    }
}

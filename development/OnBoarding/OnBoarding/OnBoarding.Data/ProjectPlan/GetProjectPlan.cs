namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class GetProjectPlan : IRequestHandler<GetProjectPlanRequest, IList<ProjectPlan>>
    {
        private readonly IRepository repository;
        public GetProjectPlan(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ProjectPlan> Handle(GetProjectPlanRequest query)
        {
            //return this.repository.Query<Entity.ProjectPlan>().Where(i => i.RoleId == query.ProjectId && i.Active).ProjectTo<ProjectPlan>().ToList();      

            var Result = (from associateDetail in repository.Query<Entity.ProjectPlan>()
                          where (associateDetail.ProjectId == query.ProjectId)
                          select new Contract.ProjectPlan
                          {
                              Week = associateDetail.Week,
                              Day = associateDetail.Day,
                              KnowledgeTransfer = new KnowledgeTransfer() { Name = associateDetail.KnowledgeTransfer.Name}

                          }).ToList();
            return Result;
        }
    }
}

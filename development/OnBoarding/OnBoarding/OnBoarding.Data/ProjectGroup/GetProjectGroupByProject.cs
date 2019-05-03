namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class GetProjectGroupByProject : IRequestHandler<GetProjectGroupByProjectRequest, IList<Contract.ProjectGroup>>
    {
        private readonly IRepository repository;
        public GetProjectGroupByProject(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Contract.ProjectGroup> Handle(GetProjectGroupByProjectRequest query)
        {
            return this.repository.Query<Entity.ProjectGroup>().Where(i => i.ProjectId == query.ProjectId && i.Active).ProjectTo<Contract.ProjectGroup>().ToList();            
        }
    }
}

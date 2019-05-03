namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract.Repository;
    using Contract;

    public class GetProject : IRequestHandler<GetProjectRequest, IList<Project>>
    {
        private readonly IRepository repository;
        public GetProject(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Project> Handle(GetProjectRequest query)
        {
            return this.repository.Query<Entity.Project>().ProjectTo<Project>().ToList();            
        }
    }
}

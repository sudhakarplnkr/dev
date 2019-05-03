

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
    using AutoMapper.QueryableExtensions;

    public class GetTeam : IRequestHandler<GetTeamRequest, IList<Team>>
    {
        private readonly IRepository repository;
        public GetTeam(IRepository objRepository)
        {
            this.repository = objRepository;
        }
        public IList<Team> Handle(GetTeamRequest query)
        {
            return repository.Query<Entities.ProjectTeam>().Where(m => m.ProjectId == query.ProjectId).ProjectTo<Team>().ToList();
        }
    }
}

namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class GetDashboardTeam : IRequestHandler<GetDashboardTeamRequest, IList<Team>>
    {
        private readonly IRepository repository;
        public GetDashboardTeam(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Team> Handle(GetDashboardTeamRequest query)
        {
            var teams = (from project in this.repository.Query<Entity.ProjectTeam>().Where(u => u.ProjectId == query.ProjectId) select new Team { Id = project.TeamId, Name = project.Team.Name }).ToList();

            return teams;

        }
    }
}

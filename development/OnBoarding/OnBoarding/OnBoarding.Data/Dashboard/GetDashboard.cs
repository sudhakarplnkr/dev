namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using Entity = OnBoarding.Entities;
    using Contract.Repository;
    using Contract;

    public class GetDashboard : IRequestHandler<GetDashboardRequest, IList<Dashboard>>
    {
        private readonly IRepository repository;
        public GetDashboard(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Dashboard> Handle(GetDashboardRequest query)
        {
            var dashboard = (from project in this.repository.Query<Entity.Project>()
                             join associate in this.repository.Query<Entity.Associate>() on project.Id equals associate.ProjectId into associateTemp
                             from associate in associateTemp.DefaultIfEmpty()
                             join team in this.repository.Query<Entity.Team>() on associate.AssociateDetails.TeamId equals team.Id into teamTemp
                             from team in teamTemp.DefaultIfEmpty()
                             join associateProject in this.repository.Query<Entity.AssociateProject>() on new { projectId = associate.ProjectId, associateId = associate.Id, status = true } equals new { projectId = associateProject.ProjectId, associateId = associateProject.AssociateId, status = associateProject.Status } into associateProjectTemp
                             from associateProject in associateProjectTemp.DefaultIfEmpty()
                             where associate.Role.Name != RoleConstant.Other
                             group new { associate, associateProject } by new
                             {
                                 projectId = project.Id,
                                 projectName = project.Name,
                                 teamId = team.Id,
                                 teamName = team.Name,
                                 roleId = associate.Role.Id,
                                 roleName = associate.Role.Name,
                                 associateId = associate.Code,
                                 associateName = associate.Name,
                                 fse = associate.AssociateDetails.Fse,
                                 fseEligibility = associate.AssociateDetails.FseEligibility
                             } into groupby
                             select new Dashboard
                             {
                                 ProjectId = groupby.Key.projectId,
                                 ProjectName = groupby.Key.projectName,
                                 TeamId = groupby.Key.teamId,
                                 TeamName = groupby.Key.teamName,
                                 RoleId = groupby.Key.roleId,
                                 RoleName = groupby.Key.roleName,
                                 AssociateId = groupby.Key.associateId,
                                 AssociateName = groupby.Key.associateName,
                                 Fse = groupby.Key.fse,
                                 FseEligibility = groupby.Key.fseEligibility,
                                 Count = groupby.Where(i => i.associate != null).Select(i => i.associate.Id).Distinct().Count(),
                                 CompletedCount = groupby.Where(i => i.associateProject != null).Select(i => i.associateProject.Id).Distinct().Count()
                             }).ToList();
            dashboard.ForEach(associate =>
            {
                associate.PodCompletionPercentage = getPodCompletionPercentage(associate.AssociateId);
            });
            return dashboard;
        }

        private int getPodCompletionPercentage(string associateCode)
        {
            var associatePlan = this.repository.Query<Entity.AssociatePlan>().Where(u => u.AssociateGroup.Associate.Code == associateCode).ToList();
            var totalCount = associatePlan.Count();
            return totalCount > 0 ? (associatePlan.Where(u => u.Status).Count() / associatePlan.Count()) * 100 : 0;
        }

    }
}

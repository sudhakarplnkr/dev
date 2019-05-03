namespace OnBoarding.Data
{
    using MediatR;
    using Contract;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public abstract class BaseProcessProjectGroup
    {
        private readonly IMediator mediatr;

        public BaseProcessProjectGroup(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        protected void SaveAssociate(Guid projectId, Guid projectGroupId, DateTime startDate, IList<Contract.Associate> associateToAdd)
        {
            var associates = associateToAdd.Select(i => i.Id).Distinct().ToList();
            var projectGroupPlans = this.GetProjectGroupPlan(projectGroupId).ToList();
            var associateGroups = this.SaveAssociateGroup(associateToAdd, projectGroupId);
            var associateGroupIds = (from i in associateGroups
                                     join b in associateToAdd on i.AssociateId equals b.Id
                                     select i.Id).ToList();
            this.SaveProjectGroupPlan(projectId, projectGroupPlans, associateGroupIds, Guid.NewGuid(), projectGroupId, startDate);
            this.UpdateScheduledDate(projectGroupPlans, startDate);
        }

        protected void DeleteAssociate(Guid projectGroupId, IList<Contract.Associate> associateToDelete)
        {
            var roles = associateToDelete.Select(i => i.RoleId).Distinct().ToList();

            var associateIds = associateToDelete.Select(i => i.Id).ToList();

            this.DeleteAssociateGroup(projectGroupId, associateIds);

            this.DeleteProjectGroupPlan(projectGroupId, roles);
        }

        #region private methods

        private void UpdateScheduledDate(IList<Contract.ProjectGroupPlan> projectGroupPlans, DateTime startDate)
        {
            foreach (var projectGroupPlan in projectGroupPlans)
            {
                this.UpdateProjectGroupPlan(projectGroupPlan, startDate);
            }
        }

        private void UpdateProjectGroupPlan(Contract.ProjectGroupPlan projectGroupPlan, DateTime startDate)
        {
            var response = this.mediatr.Send(new Contract.UpdateProjectGroupPlanRequest(new Contract.UpdateProjectGroupPlan
            {
                Week = projectGroupPlan.Week,
                Day = projectGroupPlan.Day,
                Id = projectGroupPlan.Id,
                KnowledgeTransferId = projectGroupPlan.KnowledgeTransferId,
                ModeId = projectGroupPlan.ModeId,
                OwnerId = projectGroupPlan.OwnerId,
                Reference = projectGroupPlan.Reference,
                ScheduledDate = GetScheduledDate(projectGroupPlan.Week, projectGroupPlan.Day, startDate)
            }));

            if (response.IsFaulted)
            {
                throw response.Exception;
            }
        }

        private void SaveProjectGroupPlan(Guid projectId, IList<Contract.ProjectGroupPlan> projectGroupPlans, IList<Guid> associateGroupIds, Guid role, Guid projectGroupId, DateTime startDate)
        {
            if (projectGroupPlans.Any())
            {
                foreach (var projectGroupPlan in projectGroupPlans)
                {
                    this.UpdateProjectGroupPlan(projectGroupPlan, startDate);
                    this.SaveAssociatePlan(associateGroupIds, projectGroupPlan.Id);
                }
            }
            else
            {
                var projectPlans = this.GetProjectPlan(new List<Guid> { role }, projectId);

                foreach (var projectPlan in projectPlans)
                {
                    var projectGroupPlan = this.SaveProjectGroupPlan(projectPlan, projectGroupId, startDate);

                    this.SaveAssociatePlan(associateGroupIds, projectGroupPlan.Id);
                };
            }
        }

        private IList<Contract.AssociateGroup> SaveAssociateGroup(IList<Contract.Associate> associates, Guid projectGroupId)
        {
            var associateGroups = new List<Contract.AssociateGroup>();

            foreach (var associate in associates)
            {
                var response = this.mediatr.Send(new CreateAssociateGroupRequest(new Contract.CreateAssociateGroup
                {
                    AssociateId = associate.Id,
                    ProjectGroupId = projectGroupId
                }));

                if (response.IsFaulted)
                {
                    throw response.Exception;
                }

                associateGroups.Add(response.Result);
            }

            return associateGroups;
        }

        private void SaveAssociatePlan(IList<Guid> associateGroupIds, Guid projectGroupPlanId)
        {
            foreach (var associateGroupId in associateGroupIds)
            {
                var response = this.mediatr.Send(new CreateAssociatePlanRequest(new Contract.CreateAssociatePlan
                {
                    ProjectGroupPlanId = projectGroupPlanId,
                    AssociateGroupId = associateGroupId
                }));

                if (response.IsFaulted)
                {
                    throw response.Exception;
                }
            };
        }

        private Contract.ProjectGroupPlan SaveProjectGroupPlan(Contract.ProjectPlan projectPlan, Guid projectGroupId, DateTime startDate)
        {
            var plan = new Contract.CreateProjectGroupPlan
            {
                Week = projectPlan.Week,
                Day = projectPlan.Day,
                ProjectGroupId = projectGroupId,
                KnowledgeTransferId = projectPlan.KnowledgeTransfer.Id,
                ModeId = projectPlan.KnowledgeTransfer.ModeId,
                OwnerId = projectPlan.KnowledgeTransfer.OwnerId,
                Reference = projectPlan.KnowledgeTransfer.Reference,
                ScheduledDate = GetScheduledDate(projectPlan.Week, projectPlan.Day, startDate)
            };

            var response = this.mediatr.Send(new CreateProjectGroupPlanRequest(plan));

            if (response.IsFaulted)
            {
                throw response.Exception;
            }

            return response.Result;
        }

        private void DeleteAssociateGroup(Guid projectGroupId, IList<Guid> associateIds)
        {
            var response = this.mediatr.Send(new DeleteAssociateGroupByProjectGroupRequest(projectGroupId, associateIds));

            if (response.IsFaulted)
            {
                throw response.Exception;
            }
        }

        private void DeleteProjectGroupPlan(Guid projectGroupId, List<Guid> roles)
        {
            var roleIds = GetRolesByProjectGroup(projectGroupId, roles);

            roles.RemoveAll(i => roleIds.Contains(i));

            if (roles.Any())
            {
                var projectGroupPlans = this.GetProjectGroupPlanByRoles(roles, projectGroupId);
                foreach (var projectGroupPlan in projectGroupPlans)
                {
                    var response = this.mediatr.Send(new DeleteProjectGroupPlanRequest(projectGroupPlan.Id));
                    if (response.IsFaulted)
                    {
                        throw response.Exception;
                    }
                }
            }
        }

        private IList<Guid> GetRolesByProjectGroup(Guid projectGroupId, List<Guid> roles)
        {
            var response = this.mediatr.Send(new GetRolesByProjectGroupRequest(projectGroupId, roles));

            if (response.IsFaulted)
            {
                throw response.Exception;
            }

            return response.Result.ToList();
        }

        private IList<Contract.ProjectPlan> GetProjectPlan(IList<Guid> roles, Guid projectd)
        {
            var response = this.mediatr.Send(new GetProjectPlanByProjectRequest(projectd, roles));

            if (response.IsFaulted)
            {
                throw response.Exception;
            }

            return response.Result.ToList();
        }

        private IList<Contract.ProjectGroupPlan> GetProjectGroupPlanByRoles(IList<Guid> roles, Guid projectGroupId)
        {
            var response = this.mediatr.Send(new GetProjectGroupPlanByRolesRequest(projectGroupId, roles));

            if (response.IsFaulted)
            {
                throw response.Exception;
            }

            return response.Result.ToList();
        }

        private IList<Contract.ProjectGroupPlan> GetProjectGroupPlan(Guid projectGroupId)
        {
            var response = this.mediatr.Send(new GetProjectGroupPlanRequest(projectGroupId));

            if (response.IsFaulted)
            {
                throw response.Exception;
            }

            return response.Result.ToList();
        }

        private Guid GetCommonRoleId()
        {
            var response = this.mediatr.Send(new GetRoleRequest());

            if (response.IsFaulted)
            {
                throw response.Exception;
            }

            return response.Result.Single(i => i.Code == RoleConstant.Common).Id;
        }

        private DateTime GetScheduledDate(int week, int day, DateTime startDate)
        {
            var date = startDate.AddDays(((week - 1) * 7) + (day - 1));
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(2);
            }
            return date;
        }

        #endregion
    }
}

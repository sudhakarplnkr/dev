namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class DeleteProjectGroup : IRequestHandler<DeleteProjectGroupRequest,DeleteProjectGroupResponse>
    {
        private readonly IRepository repository;
        public DeleteProjectGroup(IRepository repository)
        {
            this.repository = repository;
        }

        public DeleteProjectGroupResponse Handle(DeleteProjectGroupRequest command)
        {
            var projectGroup = this.repository.Get<Entity.ProjectGroup>(command.ProjectGroupId);

            var associateGroups = projectGroup.AssociateGroups.ToList();
            var projectGroupPlans = projectGroup.ProjectGroupPlans.ToList();

            foreach (var projectGroupPlan in projectGroupPlans)
            {
                var associatePlanStatus = projectGroupPlan.AssociatePlan.ToList();
                foreach (var associate in associatePlanStatus)
                {
                    this.repository.Delete(associate);
                }
                this.repository.Delete(projectGroupPlan);
            }

            foreach (var associateGroup in associateGroups)
            {
                this.repository.Delete(associateGroup);
            }

            this.repository.Delete(projectGroup);

            return new DeleteProjectGroupResponse();
        }
    }
}

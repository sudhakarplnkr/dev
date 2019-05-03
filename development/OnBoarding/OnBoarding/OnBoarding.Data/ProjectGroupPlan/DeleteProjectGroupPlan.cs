namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class DeleteProjectGroupPlan : IRequestHandler<DeleteProjectGroupPlanRequest,DeleteProjectGroupPlanResponse>
    {
        private readonly IRepository repository;
        public DeleteProjectGroupPlan(IRepository repository)
        {
            this.repository = repository;
        }

        public DeleteProjectGroupPlanResponse Handle(DeleteProjectGroupPlanRequest command)
        {
            var projectGroupPlan = this.repository.Get<Entity.ProjectGroupPlan>(command.ProjectGroupPlanId);

            var associatePlanStatus = projectGroupPlan.AssociatePlan.ToList();
            foreach (var associate in associatePlanStatus)
            {
                this.repository.Delete(associate);
            }
            this.repository.Delete(projectGroupPlan);

            return new DeleteProjectGroupPlanResponse();
        }
    }
}

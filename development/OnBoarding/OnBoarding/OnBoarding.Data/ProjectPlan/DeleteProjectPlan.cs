namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;

    public class DeleteProjectPlan : IRequestHandler<DeleteProjectPlanRequest,DeleteProjectPlanResponse>
    {
        private readonly IRepository repository;
        public DeleteProjectPlan(IRepository repository)
        {
            this.repository = repository;
        }

        public DeleteProjectPlanResponse Handle(DeleteProjectPlanRequest command)
        {
            var projectPlan = this.repository.Get<Entity.ProjectPlan>(command.RoleId);

            var projectPlanStatus = projectPlan.AssociatePlan.ToList();
            foreach (var associate in projectPlanStatus)
            {
                this.repository.Delete(associate);
            }
            this.repository.Delete(projectPlan);

            return new DeleteProjectPlanResponse();
        }
    }
}

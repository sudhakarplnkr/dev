namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using System.Linq;

    public class DeleteAssociatePlanByProjectGroupPlan : IRequestHandler<DeleteAssociatePlanByProjectGroupPlanRequest,DeleteAssociatePlanByProjectGroupPlanResponse>
    {
        private readonly IRepository repository;
        public DeleteAssociatePlanByProjectGroupPlan(IRepository repository)
        {
            this.repository = repository;
        }

        public DeleteAssociatePlanByProjectGroupPlanResponse Handle(DeleteAssociatePlanByProjectGroupPlanRequest command)
        {
            var associatePlans = this.repository.Query<Entity.AssociatePlan>().
                Where(i => i.ProjectGroupPlanId == command.ProjectGroupPlanId && !command.RoleIds.Contains(i.AssociateGroup.Associate.RoleId)).ToList();

            foreach (var associatePlan in associatePlans)
            {
                this.repository.Delete(associatePlan);
            }

            return new DeleteAssociatePlanByProjectGroupPlanResponse();
        }
    }
}

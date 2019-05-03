namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using System.Linq;
    using System.Collections.Generic;

    public class DeleteAssociateGroupByProjectGroup : IRequestHandler<DeleteAssociateGroupByProjectGroupRequest,DeleteAssociateGroupByProjectGroupResponse>
    {
        private readonly IRepository repository;
        public DeleteAssociateGroupByProjectGroup(IRepository repository)
        {
            this.repository = repository;
        }

        public DeleteAssociateGroupByProjectGroupResponse Handle(DeleteAssociateGroupByProjectGroupRequest command)
        {
            var associateGroups = this.repository.Query<Entity.AssociateGroup>().
                Where(i => i.ProjectGroupId == command.ProjectGroupId && command.AssociateIds.Contains(i.AssociateId)).ToList();

            foreach (var associateGroup in associateGroups)
            {
                var associatePlan = associateGroup.AssociatePlan.ToList();
                foreach (var associate in associatePlan)
                {
                    this.repository.Delete(associate);
                }
                this.repository.Delete(associateGroup);
            }

            return new DeleteAssociateGroupByProjectGroupResponse();
        }
    }
}

namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;
    using System.Linq;

    public class UpdateAssociatePlan:IRequestHandler<UpdateAssociatePlanRequest, Contract.AssociatePlan>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public UpdateAssociatePlan(IRepository repository, IMapper mapper, IMediator mediator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public Contract.AssociatePlan Handle(UpdateAssociatePlanRequest command)
        {
            var associatePlan = this.repository.Get<Entity.AssociatePlan>(command.associatePlan.Id);

            this.mapper.Map(command.associatePlan, associatePlan);
            associatePlan.Proof = command.Proof;

            this.repository.Update(associatePlan);

            this.UpdateAssociateProject(associatePlan);

            return this.mapper.Map<Entity.AssociatePlan, Contract.AssociatePlan>(associatePlan);
        }

        private void UpdateAssociateProject(Entity.AssociatePlan associatePlan)
        {
            var status = this.repository.Query<Entity.AssociatePlan>().Any(i => i.AssociateGroupId == associatePlan.AssociateGroupId && i.Id != associatePlan.Id && !i.Status);

            if (!status)
            {
                var associateProject = this.repository.Query<Entity.AssociateProject>().FirstOrDefault(i => i.ProjectId == associatePlan.ProjectGroupPlan.ProjectGroup.ProjectId && i.AssociateId == associatePlan.AssociateGroup.AssociateId);

                if (associateProject == null)
                {
                    var createAssociateGroup = new Contract.CreateAssociateProject
                    {
                        ProjectId = associatePlan.ProjectGroupPlan.ProjectGroup.ProjectId,
                        AssociateId = associatePlan.AssociateGroup.AssociateId,
                        Status = true
                    };

                    var response = mediator.Send(new CreateAssociateProjectRequest(createAssociateGroup));
                }
                else if (!associateProject.Status)
                {
                    var updateAssociateGroup = new Contract.UpdateAssociateProject
                    {
                        Id = associateProject.Id,
                        ProjectId = associatePlan.ProjectGroupPlan.ProjectGroup.ProjectId,
                        AssociateId = associatePlan.AssociateGroup.AssociateId,
                        Status = true
                    };

                    var response = mediator.Send(new UpdateAssociateProjectRequest(updateAssociateGroup));
                }
            }
        }
    }
}

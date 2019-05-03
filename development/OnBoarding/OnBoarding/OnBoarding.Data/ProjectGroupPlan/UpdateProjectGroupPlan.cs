namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class UpdateProjectGroupPlan : IRequestHandler<UpdateProjectGroupPlanRequest, Contract.ProjectGroupPlan>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public UpdateProjectGroupPlan(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.ProjectGroupPlan Handle(UpdateProjectGroupPlanRequest command)
        {
            var projectGroupPlan = this.repository.Get<Entity.ProjectGroupPlan>(command.ProjectGroupPlan.Id);

            this.mapper.Map(command.ProjectGroupPlan, projectGroupPlan);

            this.repository.Update(projectGroupPlan);

            return this.mapper.Map<Entity.ProjectGroupPlan, Contract.ProjectGroupPlan>(projectGroupPlan);
        }
    }
}

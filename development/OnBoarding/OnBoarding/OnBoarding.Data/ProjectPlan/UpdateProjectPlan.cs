namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class UpdateProjectPlan : IRequestHandler<ProcessUpdateProjectPlanRequest, Contract.ProjectPlan>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public UpdateProjectPlan(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.ProjectPlan Handle(ProcessUpdateProjectPlanRequest command)
        {
            var projectPlan = this.repository.Get<Entity.ProjectPlan>(command.ProjectPlan);

            this.mapper.Map(command.ProjectPlan, projectPlan);

            this.repository.Update(projectPlan);

            return this.mapper.Map<Entity.ProjectPlan, Contract.ProjectPlan>(projectPlan);
        }
    }
}

namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class CreateProjectPlan : IRequestHandler<CreateProjectPlanRequest, Contract.ProjectPlan>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public CreateProjectPlan(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.ProjectPlan Handle(CreateProjectPlanRequest command)
        {
            var projectPlan = this.mapper.Map<Contract.CreateProjectPlan, Entity.ProjectPlan>(command.ProjectPlan);

            this.repository.Save(projectPlan);

            return this.mapper.Map<Entity.ProjectPlan, Contract.ProjectPlan>(projectPlan);
        }
    }
}

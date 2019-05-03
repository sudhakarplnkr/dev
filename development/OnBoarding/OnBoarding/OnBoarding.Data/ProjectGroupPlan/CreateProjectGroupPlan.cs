namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class CreateProjectGroupPlan : IRequestHandler<CreateProjectGroupPlanRequest, Contract.ProjectGroupPlan>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public CreateProjectGroupPlan(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.ProjectGroupPlan Handle(CreateProjectGroupPlanRequest command)
        {
            var projectGroupPlan = this.mapper.Map<Contract.CreateProjectGroupPlan, Entity.ProjectGroupPlan>(command.ProjectGroupPlan);

            this.repository.Save(projectGroupPlan);

            return this.mapper.Map<Entity.ProjectGroupPlan, Contract.ProjectGroupPlan>(projectGroupPlan);
        }
    }
}

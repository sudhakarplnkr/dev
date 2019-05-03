namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class CreateAssociatePlan : IRequestHandler<CreateAssociatePlanRequest, Contract.AssociatePlan>
    {// 
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public CreateAssociatePlan(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.AssociatePlan Handle(CreateAssociatePlanRequest command)
        {
            var associatePlan = this.mapper.Map<Contract.CreateAssociatePlan, Entity.AssociatePlan>(command.AssociatePlan);                

            this.repository.Save(associatePlan);

            return this.mapper.Map<Entity.AssociatePlan, Contract.AssociatePlan>(associatePlan);
        }
    }
}

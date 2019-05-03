namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class CreateAssociateGroup : IRequestHandler<CreateAssociateGroupRequest, Contract.AssociateGroup>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public CreateAssociateGroup(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.AssociateGroup Handle(CreateAssociateGroupRequest command)
        {
            var associateGroup = this.mapper.Map<Contract.CreateAssociateGroup, Entity.AssociateGroup>(command.AssociateGroup);                

            this.repository.Save(associateGroup);

            return this.mapper.Map<Entity.AssociateGroup, Contract.AssociateGroup>(associateGroup);
        }
    }
}

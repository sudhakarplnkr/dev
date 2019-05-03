namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class CreateAssociateProject : IRequestHandler<CreateAssociateProjectRequest, Contract.AssociateProject>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public CreateAssociateProject(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.AssociateProject Handle(CreateAssociateProjectRequest command)
        {
            var associateProject = this.mapper.Map<Contract.CreateAssociateProject, Entity.AssociateProject>(command.AssociateProject);                

            this.repository.Save(associateProject);

            return this.mapper.Map<Entity.AssociateProject, Contract.AssociateProject>(associateProject);
        }
    }
}

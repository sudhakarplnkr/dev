namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class UpdateAssociateProject : IRequestHandler<UpdateAssociateProjectRequest, Contract.AssociateProject>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public UpdateAssociateProject(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.AssociateProject Handle(UpdateAssociateProjectRequest command)
        {
            var associateProject = this.repository.Get<Entity.AssociateProject>(command.AssociateProject.Id);

            this.mapper.Map(command.AssociateProject, associateProject);

            this.repository.Update(associateProject);

            return this.mapper.Map<Entity.AssociateProject, Contract.AssociateProject>(associateProject);
        }
    }
}

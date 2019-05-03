namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class CreateProjectGroup : IRequestHandler<CreateProjectGroupRequest, Contract.ProjectGroup>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public CreateProjectGroup(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.ProjectGroup Handle(CreateProjectGroupRequest command)
        {
            var projectGroup = this.mapper.Map<Contract.CreateProjectGroup, Entity.ProjectGroup>(command.ProjectGroup);                

            this.repository.Save(projectGroup);

            return this.mapper.Map<Entity.ProjectGroup, Contract.ProjectGroup>(projectGroup);
        }
    }
}

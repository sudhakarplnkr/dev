namespace OnBoarding.Data
{
    using MediatR;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using AutoMapper;

    public class UpdateProjectGroup : IRequestHandler<UpdateProjectGroupRequest, Contract.ProjectGroup>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public UpdateProjectGroup(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.ProjectGroup Handle(UpdateProjectGroupRequest command)
        {
            var projectGroup = this.repository.Get<Entity.ProjectGroup>(command.ProjectGroup.Id);

            this.mapper.Map(command.ProjectGroup, projectGroup);

            this.repository.Update(projectGroup);

            return this.mapper.Map<Entity.ProjectGroup, Contract.ProjectGroup>(projectGroup);
        }
    }
}

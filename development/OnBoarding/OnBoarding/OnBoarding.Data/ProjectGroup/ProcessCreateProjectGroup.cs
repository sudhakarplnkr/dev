namespace OnBoarding.Data
{
    using MediatR;
    using Contract;
    using Contract.Repository;
    using System;

    public class ProcessCreateProjectGroup : BaseProcessProjectGroup, IRequestHandler<ProcessCreateProjectGroupRequest, Contract.ProjectGroup>
    {
        private readonly IMediator mediatr;

        private readonly IRepository repository;

        public ProcessCreateProjectGroup(IMediator mediatr, IRepository repository) : base(mediatr)
        {
            this.mediatr = mediatr;
            this.repository = repository;
        }

        public Contract.ProjectGroup Handle(ProcessCreateProjectGroupRequest command)
        {
            this.repository.BeginTransaction();           

            try
            {
                var projectGroup = this.SaveProjectGroup(command);
                this.SaveAssociate(projectGroup.ProjectId, projectGroup.Id, command.ProjectGroup.StartDate, command.ProjectGroup.AddAssociates);
                this.repository.Commit();
                return projectGroup;
            }
            catch (Exception ex)
            {
                this.repository.Rollback();
                throw ex;
            }
        }

        private Contract.ProjectGroup SaveProjectGroup(ProcessCreateProjectGroupRequest command)
        {
            return this.mediatr.Send(new CreateProjectGroupRequest(new Contract.CreateProjectGroup { ProjectId = command.ProjectGroup.ProjectId, Name = command.ProjectGroup.Name, StartDate= command.ProjectGroup.StartDate })).Result;
        }
    }
}

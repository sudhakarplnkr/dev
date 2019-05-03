namespace OnBoarding.Data
{
    using MediatR;
    using Contract;
    using System;
    using System.Linq;
    using Contract.Repository;

    public class ProcessUpdateProjectGroup : BaseProcessProjectGroup, IRequestHandler<ProcessUpdateProjectGroupRequest, Contract.ProjectGroup>
    {
        private readonly IMediator mediatr;

        private readonly IRepository repository;

        public ProcessUpdateProjectGroup(IMediator mediatr, IRepository repository) : base(mediatr)
        {
            this.mediatr = mediatr;
            this.repository = repository;
        }

        public Contract.ProjectGroup Handle(ProcessUpdateProjectGroupRequest command)
        {
            this.repository.BeginTransaction();

            try
            {
                var projectGroup = this.UpdateProjectGroup(command.ProjectGroup.ProjectGroupId, command.ProjectGroup.StartDate, command.ProjectGroup.Name);

                this.SaveAssociate(projectGroup.ProjectId, projectGroup.Id, command.ProjectGroup.StartDate, command.ProjectGroup.AddAssociates);

                this.DeleteAssociate(projectGroup.Id, command.ProjectGroup.DeleteAssociates);

                this.repository.Commit();

                return projectGroup;
            }
            catch (Exception ex)
            {
                this.repository.Rollback();
                throw ex;
            }
        }

        private Contract.ProjectGroup UpdateProjectGroup(Guid projectGroupId, DateTime startDate, string projectGroupName)
        {
            return this.mediatr.Send(new UpdateProjectGroupRequest(new Contract.UpdateProjectGroup { Id = projectGroupId, Name = projectGroupName, StartDate = startDate })).Result;
        }
    }
}

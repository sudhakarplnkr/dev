namespace OnBoarding.Contract
{
    using MediatR;

    public class ProcessCreateProjectGroupRequest : IRequest<ProjectGroup>
    {
        public ProcessCreateProjectGroupRequest(ProcessCreateProjectGroup projectGroup)
        {
            this.ProjectGroup = projectGroup;
        }

        public ProcessCreateProjectGroup ProjectGroup { get; set; }
    }
}

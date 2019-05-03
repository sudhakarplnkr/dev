namespace OnBoarding.Contract
{
    using MediatR;

    public class ProcessUpdateProjectGroupRequest : IRequest<ProjectGroup>
    {
        public ProcessUpdateProjectGroupRequest(ProcessUpdateProjectGroup projectGroup)
        {
            this.ProjectGroup = projectGroup;
        }

        public ProcessUpdateProjectGroup ProjectGroup { get; set; }
    }
}

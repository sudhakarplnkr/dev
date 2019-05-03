namespace OnBoarding.Contract
{
    using MediatR;

    public class UpdateProjectGroupRequest : IRequest<ProjectGroup>
    {
        public UpdateProjectGroupRequest(UpdateProjectGroup projectGroup)
        {
            this.ProjectGroup = projectGroup;
        }

        public UpdateProjectGroup ProjectGroup { get; private set; }
    }
}

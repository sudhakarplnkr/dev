namespace OnBoarding.Contract
{
    using MediatR;

    public class CreateProjectGroupRequest : IRequest<ProjectGroup>
    {
        public CreateProjectGroupRequest(CreateProjectGroup projectGroup)
        {
            this.ProjectGroup = projectGroup;
        }

        public CreateProjectGroup ProjectGroup { get; set; }
    }
}

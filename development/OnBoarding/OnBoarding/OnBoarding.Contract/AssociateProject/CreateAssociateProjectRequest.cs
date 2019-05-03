namespace OnBoarding.Contract
{
    using MediatR;

    public class CreateAssociateProjectRequest : IRequest<AssociateProject>
    {
        public CreateAssociateProjectRequest(CreateAssociateProject projectGroup)
        {
            this.AssociateProject = projectGroup;
        }

        public CreateAssociateProject AssociateProject { get; set; }
    }
}

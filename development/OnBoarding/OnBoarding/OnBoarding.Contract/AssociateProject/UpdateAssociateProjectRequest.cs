namespace OnBoarding.Contract
{
    using MediatR;

    public class UpdateAssociateProjectRequest : IRequest<AssociateProject>
    {
        public UpdateAssociateProjectRequest(UpdateAssociateProject projectGroup)
        {
            this.AssociateProject = projectGroup;
        }

        public UpdateAssociateProject AssociateProject { get; set; }
    }
}

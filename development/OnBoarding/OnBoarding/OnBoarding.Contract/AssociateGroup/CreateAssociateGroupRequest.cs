namespace OnBoarding.Contract
{
    using MediatR;

    public class CreateAssociateGroupRequest : IRequest<AssociateGroup>
    {
        public CreateAssociateGroupRequest(CreateAssociateGroup projectGroup)
        {
            this.AssociateGroup = projectGroup;
        }

        public CreateAssociateGroup AssociateGroup { get; set; }
    }
}

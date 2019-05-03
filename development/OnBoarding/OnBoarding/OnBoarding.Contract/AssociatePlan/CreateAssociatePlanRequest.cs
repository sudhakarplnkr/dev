namespace OnBoarding.Contract
{
    using MediatR;

    public class CreateAssociatePlanRequest : IRequest<AssociatePlan>
    {
        public CreateAssociatePlanRequest(CreateAssociatePlan projectGroup)
        {
            this.AssociatePlan = projectGroup;
        }

        public CreateAssociatePlan AssociatePlan { get; set; }
    }
}

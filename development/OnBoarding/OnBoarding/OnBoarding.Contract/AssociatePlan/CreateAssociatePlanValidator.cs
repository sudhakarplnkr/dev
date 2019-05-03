namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateAssociatePlanValidator : AbstractValidator<CreateAssociatePlan>
    {
        public CreateAssociatePlanValidator()
        {
            //this.RuleFor(p => p.AssociateGroupId).NotEmpty();
        }
    }
}

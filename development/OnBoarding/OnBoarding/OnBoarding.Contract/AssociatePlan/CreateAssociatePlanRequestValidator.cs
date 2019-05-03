namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateAssociatePlanRequestValidator : AbstractValidator<CreateAssociatePlanRequest>
    {
        public CreateAssociatePlanRequestValidator()
        {
            this.RuleFor(p => p.AssociatePlan).NotNull().SetValidator(new CreateAssociatePlanValidator());
        }
    }
}

namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateProjectGroupPlanRequestValidator : AbstractValidator<CreateProjectGroupPlanRequest>
    {
        public CreateProjectGroupPlanRequestValidator()
        {
            this.RuleFor(p => p.ProjectGroupPlan).NotNull().SetValidator(new CreateProjectGroupPlanValidator());
        }
    }
}

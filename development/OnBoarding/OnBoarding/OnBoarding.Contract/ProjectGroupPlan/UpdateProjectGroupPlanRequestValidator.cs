namespace OnBoarding.Contract
{
    using FluentValidation;

    public class UpdateProjectGroupPlanRequestValidator : AbstractValidator<UpdateProjectGroupPlanRequest>
    {
        public UpdateProjectGroupPlanRequestValidator()
        {
            this.RuleFor(p => p.ProjectGroupPlan).NotNull().SetValidator(new UpdateProjectGroupPlanValidator());
        }
    }
}

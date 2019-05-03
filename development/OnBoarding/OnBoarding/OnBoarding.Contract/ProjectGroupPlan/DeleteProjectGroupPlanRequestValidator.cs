namespace OnBoarding.Contract
{
    using FluentValidation;

    public class DeleteProjectGroupPlanRequestValidator : AbstractValidator<DeleteProjectGroupPlanRequest>
    {
        public DeleteProjectGroupPlanRequestValidator()
        {
            this.RuleFor(p => p.ProjectGroupPlanId).NotEmpty();
        }
    }
}

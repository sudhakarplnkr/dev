namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateProjectGroupPlanValidator : AbstractValidator<CreateProjectGroupPlan>
    {
        public CreateProjectGroupPlanValidator()
        {
            this.RuleFor(p => p.Week).NotEmpty();

            this.RuleFor(p => p.Day).NotEmpty();

            this.RuleFor(p => p.ProjectGroupId).NotEmpty();

            this.RuleFor(p => p.KnowledgeTransferId).NotEmpty();

            this.RuleFor(p => p.ModeId).NotEmpty();

            this.RuleFor(p => p.Reference).NotNull().NotEmpty();

            this.RuleFor(p => p.ScheduledDate).NotEmpty();
        }
    }
}

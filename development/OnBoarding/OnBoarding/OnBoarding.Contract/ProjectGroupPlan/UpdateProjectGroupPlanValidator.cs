namespace OnBoarding.Contract
{
    using FluentValidation;

    public class UpdateProjectGroupPlanValidator : AbstractValidator<UpdateProjectGroupPlan>
    {
        public UpdateProjectGroupPlanValidator()
        {
            this.RuleFor(p => p.Id).NotEmpty();

            this.RuleFor(p => p.Week).NotEmpty();

            this.RuleFor(p => p.Day).NotEmpty();

            this.RuleFor(p => p.KnowledgeTransferId).NotEmpty();

            this.RuleFor(p => p.ModeId).NotEmpty();

            this.RuleFor(p => p.RoleId).NotEmpty();

            this.RuleFor(p => p.ScheduledDate).NotEmpty();
        }
    }
}

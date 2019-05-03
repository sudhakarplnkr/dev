namespace OnBoarding.Contract
{
    using FluentValidation;

    public class DeleteProjectGroupRequestValidator : AbstractValidator<DeleteProjectGroupRequest>
    {
        public DeleteProjectGroupRequestValidator()
        {
            this.RuleFor(p => p.ProjectGroupId).NotEmpty();
        }
    }
}

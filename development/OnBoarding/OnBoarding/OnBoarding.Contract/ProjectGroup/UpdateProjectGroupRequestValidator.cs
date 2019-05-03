namespace OnBoarding.Contract
{
    using FluentValidation;

    public class UpdateProjectGroupRequestValidator : AbstractValidator<UpdateProjectGroupRequest>
    {
        public UpdateProjectGroupRequestValidator()
        {
            this.RuleFor(p => p.ProjectGroup).NotNull().SetValidator(new UpdateProjectGroupValidator());
        }
    }
}

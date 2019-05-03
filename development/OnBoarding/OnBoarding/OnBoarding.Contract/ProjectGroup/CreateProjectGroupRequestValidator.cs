namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateProjectGroupRequestValidator : AbstractValidator<CreateProjectGroupRequest>
    {
        public CreateProjectGroupRequestValidator()
        {
            this.RuleFor(p => p.ProjectGroup).NotNull().SetValidator(new CreateProjectGroupValidator());
        }
    }
}

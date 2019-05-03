namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateProjectGroupValidator : AbstractValidator<CreateProjectGroup>
    {
        public CreateProjectGroupValidator()
        {
            this.RuleFor(p => p.ProjectId).NotEmpty();

            this.RuleFor(p => p.Name).NotEmpty();
        }
    }
}

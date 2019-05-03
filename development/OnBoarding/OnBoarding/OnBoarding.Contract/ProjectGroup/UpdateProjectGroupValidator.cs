namespace OnBoarding.Contract
{
    using FluentValidation;

    public class UpdateProjectGroupValidator : AbstractValidator<UpdateProjectGroup>
    {
        public UpdateProjectGroupValidator()
        {
            this.RuleFor(p => p.Id).NotEmpty();

            this.RuleFor(p => p.Name).NotEmpty();
        }
    }
}

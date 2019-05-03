namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateAssociateGroupValidator : AbstractValidator<CreateAssociateGroup>
    {
        public CreateAssociateGroupValidator()
        {
            //this.RuleFor(p => p.ProjectId).NotEmpty();

            //this.RuleFor(p => p.Name).NotEmpty();
        }
    }
}

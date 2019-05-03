namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateAssociateProjectValidator : AbstractValidator<CreateAssociateProject>
    {
        public CreateAssociateProjectValidator()
        {
            //this.RuleFor(p => p.ProjectId).NotEmpty();

            //this.RuleFor(p => p.Name).NotEmpty();
        }
    }
}

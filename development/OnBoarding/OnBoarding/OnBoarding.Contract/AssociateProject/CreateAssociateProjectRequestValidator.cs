namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateAssociateProjectRequestValidator : AbstractValidator<CreateAssociateProjectRequest>
    {
        public CreateAssociateProjectRequestValidator()
        {
            this.RuleFor(p => p.AssociateProject).NotNull().SetValidator(new CreateAssociateProjectValidator());
        }
    }
}

namespace OnBoarding.Contract
{
    using FluentValidation;

    public class CreateAssociateGroupRequestValidator : AbstractValidator<CreateAssociateGroupRequest>
    {
        public CreateAssociateGroupRequestValidator()
        {
            this.RuleFor(p => p.AssociateGroup).NotNull().SetValidator(new CreateAssociateGroupValidator());
        }
    }
}

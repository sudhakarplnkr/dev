namespace OnBoarding.Contract
{
    using FluentValidation;

    public class UpdateAssociateProjectRequestValidator : AbstractValidator<UpdateAssociateProjectRequest>
    {
        public UpdateAssociateProjectRequestValidator()
        {
            this.RuleFor(p => p.AssociateProject).NotNull().SetValidator(new UpdateAssociateProjectValidator());
        }
    }
}

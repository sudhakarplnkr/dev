namespace OnBoarding.Contract
{
    using FluentValidation;

    public class UpdateAssociateProjectValidator : AbstractValidator<UpdateAssociateProject>
    {
        public UpdateAssociateProjectValidator()
        {
            //this.RuleFor(p => p.ProjectId).NotEmpty();

            //this.RuleFor(p => p.Name).NotEmpty();
        }
    }
}

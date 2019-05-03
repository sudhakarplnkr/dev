namespace OnBoarding.Contract
{
    using FluentValidation;

    public class DeleteAssociateGroupByProjectGroupRequestValidator : AbstractValidator<DeleteAssociateGroupByProjectGroupRequest>
    {
        public DeleteAssociateGroupByProjectGroupRequestValidator()
        {
            //this.RuleFor(p => p.AssociateGroupByProjectGroupId).NotEmpty();
        }
    }
}

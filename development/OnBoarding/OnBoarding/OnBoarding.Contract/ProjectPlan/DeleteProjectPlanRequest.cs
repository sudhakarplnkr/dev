namespace OnBoarding.Contract
{
    using MediatR;
    using System;

    public class DeleteProjectPlanRequest : IRequest<DeleteProjectPlanResponse>
    {
        public DeleteProjectPlanRequest(Guid roleId)
        {
            this.RoleId = roleId;
        }
         
        public Guid RoleId { get; private set; }
    }
}

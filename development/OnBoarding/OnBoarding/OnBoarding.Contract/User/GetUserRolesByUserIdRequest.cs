namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;
    using MediatR;
    public class GetUserRolesByUserIdRequest : IRequest<IList<UserRole>>
    {
        public string UserId { get; private set; }
        public GetUserRolesByUserIdRequest(string userId)
        {
            this.UserId = userId;
        }

    }
}

namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;
    using MediatR;

    public  class GetAssociatePlanRequest : IRequest<IList<AssociatePlan>>
    {
        public GetAssociatePlanRequest(string LoginID)
        {
            this.LoginID = LoginID;
        }
        public string LoginID { get; private set; }
    }
}

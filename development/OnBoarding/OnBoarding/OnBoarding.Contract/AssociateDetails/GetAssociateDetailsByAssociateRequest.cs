using MediatR;
using System.Collections.Generic;

namespace OnBoarding.Contract
{
    public class GetAssociateDetailsByAssociateRequest : IRequest<Response<IList<AssociateDetails>>>
    {
        public GetAssociateDetailsByAssociateRequest(PageRequest pageRequest)
        {
            this.PageRequest = pageRequest;                        
        }

        public PageRequest PageRequest { get; set; }
    }
}

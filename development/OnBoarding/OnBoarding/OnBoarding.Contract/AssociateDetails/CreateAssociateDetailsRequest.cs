using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Contract
{
    public class CreateAssociateDetailsRequest: IRequest<AssociateDetails>
    { 
        public CreateAssociateDetailsRequest(AssociateDetails associateDetails)
        {
            this.AssociateDetails = associateDetails;
        }
        public AssociateDetails AssociateDetails { get; set; }
    }
}

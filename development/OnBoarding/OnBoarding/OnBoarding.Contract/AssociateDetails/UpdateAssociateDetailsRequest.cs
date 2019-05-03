using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Contract
{
    public class UpdateAssociateDetailsRequest : IRequest<UpdateAssociateDetails>
    {
        public UpdateAssociateDetailsRequest(UpdateAssociateDetails associateDetails)
        {
        this.AssociateDetails = associateDetails;
        }

        public UpdateAssociateDetails AssociateDetails { get; private set; }
    }
}
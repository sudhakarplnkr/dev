namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediatR;
  public class DeleteAssociateDetailsRequest:IRequest<DeleteAssociateDetails>
    {
        public DeleteAssociateDetailsRequest(Guid associateId)
        {
            AssociateId = associateId;
        }
        public Guid AssociateId { get; private set; }
    }
}

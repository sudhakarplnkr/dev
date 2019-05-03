namespace OnBoarding.Contract
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using MediatR;

   public class UpdateAssociatePlanRequest:IRequest<AssociatePlan>
    {
        public UpdateAssociatePlanRequest(UpdateAssociatePlan associatePlan, byte[] proof)
        {
            this.associatePlan = associatePlan;
            this.Proof = proof;
        }
        public UpdateAssociatePlan associatePlan { get; set; }
        public byte[] Proof { get; set; }
    }
}

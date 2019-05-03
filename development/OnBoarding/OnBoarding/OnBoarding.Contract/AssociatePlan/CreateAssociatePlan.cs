namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;

    public class CreateAssociatePlan
    {
        public Guid AssociateGroupId { get; set; }

        public Guid ProjectGroupPlanId { get; set; }
    }
}

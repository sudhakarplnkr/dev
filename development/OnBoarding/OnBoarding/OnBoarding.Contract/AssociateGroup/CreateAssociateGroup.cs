namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;

    public class CreateAssociateGroup
    {
        public Guid ProjectGroupId { get; set; }

        public Guid AssociateId { get; set; }
    }
}

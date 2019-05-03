namespace OnBoarding.Contract
{
    using System;
    public class AssociateGroup
    {
        public Guid Id { get; set; }

        public Guid ProjectGroupId { get; set; }

        public Guid AssociateId { get; set; }
    }
}

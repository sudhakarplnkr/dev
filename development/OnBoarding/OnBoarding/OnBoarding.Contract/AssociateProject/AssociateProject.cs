namespace OnBoarding.Contract
{
    using System;
    public class AssociateProject
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid AssociateId { get; set; }
    }
}

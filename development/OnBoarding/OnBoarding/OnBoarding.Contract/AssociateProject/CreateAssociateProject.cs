namespace OnBoarding.Contract
{
    using System;

    public class CreateAssociateProject
    {
        public Guid ProjectId { get; set; }

        public Guid AssociateId { get; set; }

        public bool Status { get; set; }
    }
}

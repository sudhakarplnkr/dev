namespace OnBoarding.Contract
{
    using System;

    public class UpdateAssociateProject
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid AssociateId { get; set; }

        public bool Status { get; set; }
    }
}

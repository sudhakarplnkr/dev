namespace OnBoarding.Entities
{
    using System;
    using System.Collections.Generic;

    public class AssociateProject
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public Guid AssociateId { get; set; }

        public Associate Associate { get; set; }

        public bool Status { get; set; }

        public bool Active { get; set; }
    }
}

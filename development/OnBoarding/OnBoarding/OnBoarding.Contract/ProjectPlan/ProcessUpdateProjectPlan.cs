namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;

    public class ProcessUpdateProjectPlan
    {
        public Guid Id { get { return Guid.NewGuid(); } }

        public Guid ProjectId { get; set; }

        public Guid RoleId { get; set; }

        public Guid KnowledgeTransferId { get; set; }

        public int Week { get; set; }

        public int Day { get; set; }
    }
}

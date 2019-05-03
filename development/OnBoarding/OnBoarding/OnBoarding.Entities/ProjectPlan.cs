namespace OnBoarding.Entities
{
    using System;
    using System.Collections.Generic;

    public class ProjectPlan
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

       // public Guid RoleId { get; set; }

        // public virtual Role Role { get; set; }

        public int Week { get; set; }

        public int Day { get; set; }

        public Guid KnowledgeTransferId { get; set; }

        public virtual KnowledgeTransfer KnowledgeTransfer { get; set; }

        public virtual ICollection<AssociatePlan> AssociatePlan { get; set; } = new List<AssociatePlan>();

        public bool Active { get; set; }
    }
}

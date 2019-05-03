namespace OnBoarding.Entities
{
    using System;
    using System.Collections.Generic;

    public class ProjectGroupPlan
    {
        public Guid Id { get; set; }

        public Guid ProjectGroupId { get; set; }

        public virtual ProjectGroup ProjectGroup { get; set; }

        public int Week { get; set; }

        public int Day { get; set; }

        public Guid KnowledgeTransferId { get; set; }

        public virtual KnowledgeTransfer KnowledgeTransfer { get; set; }

        public Guid ModeId { get; set; }

        public virtual Mode Mode { get; set; }

        public Guid? OwnerId { get; set; }

        public Associate Owner { get; set; }

        public string Reference { get; set; }
        
        public DateTime ScheduledDate { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<AssociatePlan> AssociatePlan { get; set; } = new List<AssociatePlan>();
    }
}

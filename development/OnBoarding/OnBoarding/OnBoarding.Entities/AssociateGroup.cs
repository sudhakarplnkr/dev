namespace OnBoarding.Entities
{
    using System;
    using System.Collections.Generic;

    public class AssociateGroup
    {
        public Guid Id { get; set; }

        public Guid ProjectGroupId { get; set; }

        public ProjectGroup ProjectGroup { get; set; }

        public Guid AssociateId { get; set; }

        public Associate Associate { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<AssociatePlan> AssociatePlan { get; set; } = new List<AssociatePlan>();
    }
}

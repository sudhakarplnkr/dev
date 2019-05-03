namespace OnBoarding.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ProjectGroup
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<AssociateGroup> AssociateGroups { get; set; }

        public virtual ICollection<ProjectGroupPlan> ProjectGroupPlans { get; set; }
    }
}

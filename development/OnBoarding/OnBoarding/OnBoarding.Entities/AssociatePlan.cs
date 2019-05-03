namespace OnBoarding.Entities
{
    using System;

    public class AssociatePlan
    {
        public Guid Id { get; set; }

        public Guid AssociateGroupId { get; set; }

        public virtual AssociateGroup AssociateGroup { get; set; }

        public Guid ProjectGroupPlanId { get; set; }

        public virtual ProjectGroupPlan ProjectGroupPlan { get; set; }

        public bool Status { get; set; }

        public DateTime? CompletionDate { get; set; }

        public byte[] Proof { get; set; }

        public bool Active { get; set; }
    }
}

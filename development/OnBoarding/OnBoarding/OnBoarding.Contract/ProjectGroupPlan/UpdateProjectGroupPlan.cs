namespace OnBoarding.Contract
{
    using System;

    public class UpdateProjectGroupPlan
    {
        public Guid Id { get; set; }

        public int Week { get; set; }

        public int Day { get; set; }

        public Guid KnowledgeTransferId { get; set; }

        public string Reference { get; set; }

        public Guid ModeId { get; set; }
        
        public Guid RoleId { get; set; }

        public Guid? OwnerId { get; set; }

        public DateTime ScheduledDate { get; set; }
    }
}

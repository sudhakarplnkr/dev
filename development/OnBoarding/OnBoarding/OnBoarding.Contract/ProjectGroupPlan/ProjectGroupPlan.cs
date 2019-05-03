namespace OnBoarding.Contract
{
    using System;

    public class ProjectGroupPlan
    {
        public Guid Id { get; set; }

        public int Week { get; set; }

        public int Day { get; set; }

        public Guid KnowledgeTransferId { get; set; }

        public string KnowledgeTransferName { get; set; }

        public string Reference { get; set; }

        public decimal Duration { get; set; }

        public Guid ModeId { get; set; }

        public string ModeName { get; set; }

        public Guid? OwnerId { get; set; }

        public string OwnerName { get; set; }

        public DateTime ScheduledDate { get; set; }

        public Guid ProjectGroupId { get; set; }
    }
}

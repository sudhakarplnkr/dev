namespace OnBoarding.Contract
{
    using System;

    public class CreateProjectPlan 
    {
        public Guid Id { get { return Guid.NewGuid(); } }

        public Guid ProjectId { get; set; } 

        public Guid KnowledgeTransferId { get; set; }

        public int Week { get; set; }

        public int Day { get; set; }
    }
}

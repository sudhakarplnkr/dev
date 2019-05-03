namespace OnBoarding.Contract
{
    using System;
   public class AssociatePlan
    {
        public Guid Id { get; set; }

        public Guid AssociateId { get; set; }

        public string AssociateCode { get; set; }

        public string AssociateName { get; set; }

        public string OwnerName { get; set; }

        public string ModeName { get; set; }

        public string  Reference { get; set; }
        
        public string KnowledgeTransferTitle { get; set; }

        public decimal Duration { get; set; }

        public int Week { get; set; }

        public int Day { get; set; }

        public DateTime ScheduledDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public byte[] Proof { get; set; }

        public int ProofType { get; set; }
    }
}

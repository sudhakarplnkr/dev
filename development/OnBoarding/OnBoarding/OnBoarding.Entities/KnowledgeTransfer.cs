namespace OnBoarding.Entities
{
    using System;

    public class KnowledgeTransfer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ModeId { get; set; }

        public virtual Mode Mode { get; set; }

        public Guid? OwnerId { get; set; }

        public Associate Owner { get; set; }

        public string Reference { get; set; }

        public decimal Duration { get; set; }

        public bool Active { get; set; }
         
    }
}

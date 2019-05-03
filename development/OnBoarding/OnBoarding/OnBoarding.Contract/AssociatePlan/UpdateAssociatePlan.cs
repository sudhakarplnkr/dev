namespace OnBoarding.Contract
{
    using System;

    public class UpdateAssociatePlan
    {
        public Guid Id { get; set; }

        public bool Status { get; set; }

        public DateTime CompletionDate { get; set; }        
    }
}

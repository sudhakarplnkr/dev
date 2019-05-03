namespace OnBoarding.Entities
{
    using System;

    public class Mode
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int ProofType { get; set; }
    }
}

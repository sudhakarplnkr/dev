namespace OnBoarding.Contract
{
    using System;

    public class UpdateProjectGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }
    }
}

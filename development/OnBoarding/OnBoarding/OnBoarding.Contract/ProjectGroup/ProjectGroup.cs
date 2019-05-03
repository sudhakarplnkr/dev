namespace OnBoarding.Contract
{
    using System;

    public class ProjectGroup
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}

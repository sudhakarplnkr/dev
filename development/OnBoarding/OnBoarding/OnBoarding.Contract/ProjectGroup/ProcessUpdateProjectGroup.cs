namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;

    public class ProcessUpdateProjectGroup
    {
        public Guid ProjectGroupId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public IList<Associate> AddAssociates { get; set; }

        public IList<Associate> DeleteAssociates { get; set; }
    }
}

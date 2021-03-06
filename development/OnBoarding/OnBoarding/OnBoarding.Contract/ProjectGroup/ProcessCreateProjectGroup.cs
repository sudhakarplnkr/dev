﻿namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;

    public class ProcessCreateProjectGroup
    {
        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public IList<Associate> AddAssociates { get; set; }
    }
}

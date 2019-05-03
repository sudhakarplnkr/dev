namespace OnBoarding.Contract
{
    using System;

    public class ProjectGroupPlanWithStatus : ProjectGroupPlan
    {
        public int TotalCount { get; set; }

        public int CompletedCount { get; set; }
    }
}

namespace OnBoarding.Contract
{
    using System;

    public class Dashboard
    {
        public Guid ProjectId { get; set; }

        public Guid? TeamId { get; set; }

        public Guid? RoleId { get; set; }

        public string ProjectName { get; set; }

        public string TeamName { get; set; }

        public string RoleName { get; set; }

        public int Count { get; set; }

        public int CompletedCount { get; set; }

        public string AssociateId { get; set; }  

        public string AssociateName { get; set; }

        public int PodCompletionPercentage { get; set; }
               
        public bool? Fse { get; set; } 

        public bool? FseEligibility { get; set; }

        public int DesiredLevel { get; set; }
    }

    
}

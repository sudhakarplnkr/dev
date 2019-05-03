namespace OnBoarding.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ProjectTeam
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public Guid TeamId { get; set; }

        public virtual Team Team { get; set; }

        public string ScrumMaster { get; set; }

        public string ProductOwner { get; set; }

        public string ClientDeveloper { get; set; }

        public string ClientTester { get; set; }

        public string ClientBusinessAnalyst { get; set; }

        public string ClientUserInterface { get; set; }

        public bool Active { get; set; }    
    }
}

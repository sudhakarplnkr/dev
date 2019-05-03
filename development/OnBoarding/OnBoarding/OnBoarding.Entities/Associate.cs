namespace OnBoarding.Entities
{
    using System;

    public class Associate
    {        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual AssociateDetails AssociateDetails { get; set; }

        public bool Active { get; set; }
    }
}

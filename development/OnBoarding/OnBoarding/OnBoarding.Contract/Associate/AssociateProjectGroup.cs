namespace OnBoarding.Contract
{
    using System;
    public class AssociateProjectGroup
    {
        public Guid Id { get; set; }

        public Guid? AssociateGroupId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Guid RoleId { get; set; }    
          
        public bool IsGroup { get; set; }
    }
}

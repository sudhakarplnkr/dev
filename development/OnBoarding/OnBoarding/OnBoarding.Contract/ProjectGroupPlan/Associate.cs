namespace OnBoarding.Contract
{
    using System;

    public class Associate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid DesignationId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid RoleId { get; set; }
        public int Active { get; set; }
    }
}

namespace OnBoarding.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AssociateDetails
    {
        [Key, ForeignKey("Associate")]
        public Guid AssociateId { get; set; }

        public virtual Associate Associate { get; set; }

        public Guid? DesignationId { get; set; }

        public virtual Designation Designation { get; set; }
        
        public string FNZUserName { get; set; }

        public string FNZStaffId { get; set; }

        public Guid? FNZRoleId { get; set; }

        public string FNZEmail { get; set; }

        public string AssetNo { get; set; }

        public string VirtualMachineNo { get; set; }

        public string Portfolio { get; set; }

        public DateTime? FNZDateofJoining { get; set; }

        public DateTime? FNZDateofLeaving { get; set; }

        public int? FNZExperience { get; set; }

        public string Billable { get; set; }

        public string Location { get; set; }

        public string ContactNo { get; set; }

        public Guid? TeamId { get; set; }

        public virtual Team Team { get; set; }

        public string EmailId { get; set; }        

        public string City { get; set; }
        
        public string SkillSet { get; set; }

        public int? ExperienceOfAssociate { get; set; }

        public bool? Fse { get; set; }

        public bool? FseEligibility { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Contract
{
    public class AssociateDetails
    {
        public Guid AssociateId { get; set; }

        //public virtual Associate Associate { get; set; }

        public Guid? DesignationId { get; set; }

        public string CognizantId { get; set; }

        public string AssociateName { get; set; }

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

        public Guid ProjectId { get; set; }

        public Guid? TeamId { get; set; }

        public Guid CognizantRoleId { get; set; }

        public string CognizantEmailId { get; set; }

        public string ProjectName { get; set; }

        public string City { get; set; }

        public string SkillSet { get; set; }

        public int? ExperienceOfAssociate { get; set; }

        public bool? Fse { get; set; }

        public bool? FseEligibility { get; set; }
    }
}

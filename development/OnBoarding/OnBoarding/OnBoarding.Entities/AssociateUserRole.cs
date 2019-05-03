
namespace OnBoarding.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AssociateUserRole
    {
        public Guid Id { get; set; }
        public Guid AssociateId { get; set; }
        public Guid UserRoleId { get; set; }
        public virtual Associate Associate { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}

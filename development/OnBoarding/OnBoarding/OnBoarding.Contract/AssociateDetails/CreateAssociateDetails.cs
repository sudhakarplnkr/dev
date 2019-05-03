using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Contract
{
    public class CreateAssociateDetails
    {
        public virtual Associate Associate { get; set; }

        public Guid? DesignationId { get; set; }
    }
}

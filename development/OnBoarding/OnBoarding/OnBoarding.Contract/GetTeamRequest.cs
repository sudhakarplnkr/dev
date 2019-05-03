using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnBoarding.Contract
{
   public class GetTeamRequest : IRequest<IList<Team>>
    {
        public GetTeamRequest(Guid projectId)
        {
            this.ProjectId = projectId;
        }
        public Guid ProjectId { get; set; }
    }
}

namespace OnBoarding.Contract
{
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetDashboardTeamRequest : IRequest<IList<Team>>
    {
        public GetDashboardTeamRequest(Guid projectId) 
        {
            this.ProjectId = projectId;
        }
         
        public Guid ProjectId { get; private set; }
    } 
}

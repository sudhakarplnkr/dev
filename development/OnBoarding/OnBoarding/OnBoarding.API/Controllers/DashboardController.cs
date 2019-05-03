using MediatR;
using OnBoarding.Contract;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly IMediator mediatr;

        public DashboardController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public HomeDashboard Get()
        {
            var dashboardResponse = this.mediatr.Send(new GetDashboardRequest());
            var response = this.mediatr.Send(new GetDashboardFseRequest());
            var homeDashboard = new HomeDashboard
            {
                Dashboard = dashboardResponse.Result,
                Fse = response.Result
            };
            return homeDashboard;
        }
        [HttpGet]
        [Route("api/Dashboard/Query")]
        public IList<Team> Query(Guid ProjectId)     
        {
            var response = this.mediatr.Send(new GetDashboardTeamRequest(ProjectId));

            return response.Result;
        }
    }
}
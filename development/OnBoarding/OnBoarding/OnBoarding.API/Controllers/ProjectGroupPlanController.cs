using MediatR;
using OnBoarding.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnBoarding.WebAPI.Controllers
{
    public class ProjectGroupPlanController : ApiController
    {
        private readonly IMediator mediatr;

        public ProjectGroupPlanController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public IList<ProjectGroupPlanWithStatus> Query(Guid ProjectGroupId)
        {
            var response = this.mediatr.Send(new GetProjectGroupPlanWithStatusRequest(ProjectGroupId));

            return response.Result;
        }

        [HttpPost]
        public ProjectGroupPlan Post([FromBody] CreateProjectGroupPlan request)
        {
            var response = this.mediatr.Send(new CreateProjectGroupPlanRequest(request));

            this.SaveAssociatePlan(response.Result);

            return response.Result;
        }

        [HttpPut]
        public ProjectGroupPlan Put(Guid id, [FromBody] UpdateProjectGroupPlan request)
        {
            var response = this.mediatr.Send(new UpdateProjectGroupPlanRequest(request));

            this.DeleteAssociatePlan(response.Result);
            this.SaveAssociatePlan(response.Result);

            return response.Result;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            this.mediatr.Send(new DeleteProjectGroupPlanRequest(id));            
        }

        private void SaveAssociatePlan(ProjectGroupPlan projectGroupPlan)
        {
            var response = this.mediatr.Send(new GetAssociateGroupByProjectGroupRequest(projectGroupPlan.ProjectGroupId, projectGroupPlan.Id));

            foreach (var associateGroup in response.Result)
            {
                var associate = this.mediatr.Send(new CreateAssociatePlanRequest(new Contract.CreateAssociatePlan
                {
                    ProjectGroupPlanId = projectGroupPlan.Id,
                    AssociateGroupId = associateGroup.Id
                }));
            };
        }

        private void DeleteAssociatePlan(ProjectGroupPlan projectGroupPlan)
        {
            var response = this.mediatr.Send(new DeleteAssociatePlanByProjectGroupPlanRequest(projectGroupPlan.Id, new List<Guid> {}));
        }

        private Guid GetCommonRoleId()
        {
            var response = this.mediatr.Send(new GetRoleRequest());

            return response.Result.Single(i => i.Code == RoleConstant.Common).Id;
        }
    }
}
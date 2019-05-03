namespace OnBoarding.Contract
{
    using MediatR;

    public class UpdateProjectGroupPlanRequest : IRequest<ProjectGroupPlan>
    {
        public UpdateProjectGroupPlanRequest(UpdateProjectGroupPlan projectGroupPlan)
        {
            this.ProjectGroupPlan = projectGroupPlan;
        }

        public UpdateProjectGroupPlan ProjectGroupPlan { get; private set; }
    }
}

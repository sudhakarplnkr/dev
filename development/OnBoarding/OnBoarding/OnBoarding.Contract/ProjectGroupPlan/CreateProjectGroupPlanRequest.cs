namespace OnBoarding.Contract
{
    using MediatR;

    public class CreateProjectGroupPlanRequest : IRequest<ProjectGroupPlan>
    {
        public CreateProjectGroupPlanRequest(CreateProjectGroupPlan projectGroupPlan)
        {
            this.ProjectGroupPlan = projectGroupPlan;
        }

        public CreateProjectGroupPlan ProjectGroupPlan { get; set; }
    }
}

namespace OnBoarding.Contract
{
    using MediatR;

    public class CreateProjectPlanRequest : IRequest<ProjectPlan>
    {
        public CreateProjectPlanRequest(CreateProjectPlan projectPlan)
        {
            this.ProjectPlan = projectPlan;
        }

        public CreateProjectPlan ProjectPlan { get; set; }
    }
}

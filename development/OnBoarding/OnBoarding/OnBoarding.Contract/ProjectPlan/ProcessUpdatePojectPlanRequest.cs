namespace OnBoarding.Contract
{
    using MediatR;

    public class ProcessUpdateProjectPlanRequest : IRequest<ProjectPlan>
    {
        public ProcessUpdateProjectPlanRequest(ProcessUpdateProjectPlan projectPlan)
        {
            this.ProjectPlan = projectPlan;
        }

        public ProcessUpdateProjectPlan ProjectPlan { get; set; }
    }
}

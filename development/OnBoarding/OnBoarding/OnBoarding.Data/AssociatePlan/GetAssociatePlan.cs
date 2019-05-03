namespace OnBoarding.Data
{
    using MediatR;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract;
    using Contract.Repository;
    using System.Linq;
    using System.Collections.Generic;
    public class GetAssociatePlan : IRequestHandler<GetAssociatePlanRequest,IList<Contract.AssociatePlan>>
    {
        private readonly IRepository repository;
        
        public GetAssociatePlan(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Contract.AssociatePlan> Handle(GetAssociatePlanRequest query)
        {
            return this.repository.Query<Entity.AssociatePlan>().Where(i => i.AssociateGroup.Associate.Code.ToString() == query.LoginID.ToString() && i.Active).OrderBy(i=>i.ProjectGroupPlan.Week).ThenBy(t=>t.ProjectGroupPlan.Day).ProjectTo<Contract.AssociatePlan>().ToList();
        }
    }
}

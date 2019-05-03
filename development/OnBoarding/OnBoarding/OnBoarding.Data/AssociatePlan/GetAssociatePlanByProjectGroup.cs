namespace OnBoarding.Data
{
    using MediatR;
    using AutoMapper.QueryableExtensions;
    using Contract;
    using Contract.Repository;
    using System.Linq;
    using System.Collections.Generic;
    public class GetAssociatePlanByProjectGroup : IRequestHandler<GetAssociatePlanByProjectGroupRequest,IList<Contract.AssociatePlan>>
    {
        private readonly IRepository repository;
        
        public GetAssociatePlanByProjectGroup(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Contract.AssociatePlan> Handle(GetAssociatePlanByProjectGroupRequest query)
        {
            return repository.Query<Entities.AssociatePlan>()
                             .Where(i => i.ProjectGroupPlanId == query.ProjectGroupPlanId && i.AssociateGroup.Associate.Active).OrderBy(i=> i.AssociateGroup.Associate.Name)
                             .ProjectTo<Contract.AssociatePlan>().ToList();
        }
    }
}

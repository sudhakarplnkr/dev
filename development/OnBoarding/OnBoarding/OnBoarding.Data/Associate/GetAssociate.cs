namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract.Repository;
    using Contract;

    public class GetAssociate : IRequestHandler<GetAssociateRequest, IList<Contract.Associate>>
    {
        private readonly IRepository repository;
        public GetAssociate(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Contract.Associate> Handle(GetAssociateRequest query)
        {
            return this.repository.Query<Entity.Associate>().ProjectTo<Contract.Associate>().ToList();            
        }
    }
}

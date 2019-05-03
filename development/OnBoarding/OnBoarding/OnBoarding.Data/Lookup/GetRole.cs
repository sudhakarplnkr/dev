namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract.Repository;
    using Contract;

    public class GetRole : IRequestHandler<GetRoleRequest, IList<Role>>
    {
        private readonly IRepository repository;
        public GetRole(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Role> Handle(GetRoleRequest query)
        {
            return this.repository.Query<Entity.Role>().ProjectTo<Role>().ToList();            
        }
    }
}

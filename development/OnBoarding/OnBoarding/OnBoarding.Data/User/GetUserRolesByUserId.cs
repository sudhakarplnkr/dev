
namespace OnBoarding.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using MediatR;
    using Contract;
    using Contract.Repository;
    using AutoMapper.QueryableExtensions;
    public class GetUserRolesByUserId : IRequestHandler<GetUserRolesByUserIdRequest, IList<UserRole>>
    {
        private readonly IRepository repository;
        public GetUserRolesByUserId(IRepository _repository)
        {
            repository = _repository;
        }

        public IList<UserRole> Handle(GetUserRolesByUserIdRequest query)
        {
            return repository.Query<Entities.AssociateUserRole>().Where(m => m.Associate.Code == query.UserId && m.Associate.Active)
                .ProjectTo<UserRole>().ToList();
        }
    }
}

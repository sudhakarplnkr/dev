namespace OnBoarding.Data
{
    using AutoMapper.QueryableExtensions;
    using Contract;
    using Contract.Repository;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    public class GetAccountRole : IRequestHandler<GetAccountRoleRequest, IList<AccountRole>>
    {
        private readonly IRepository repository;
        public GetAccountRole(IRepository objRepository)
        {
            repository = objRepository;
        }
        public IList<AccountRole> Handle(GetAccountRoleRequest objRequest)
        {
            return repository.Query<Entities.AccountRole>().ProjectTo<AccountRole>().ToList();
        }
    }
}

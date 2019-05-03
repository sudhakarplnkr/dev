namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract.Repository;
    using Contract;

    public class GetMode : IRequestHandler<GetModeRequest, IList<Mode>>
    {
        private readonly IRepository repository;
        public GetMode(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<Mode> Handle(GetModeRequest query)
        {
            return this.repository.Query<Entity.Mode>().ProjectTo<Mode>().ToList();            
        }
    }
}

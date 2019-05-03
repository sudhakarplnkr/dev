namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Entity = OnBoarding.Entities;
    using Contract.Repository;
    using Contract;

    public class GetKnowledgeTransfer : IRequestHandler<GetKnowledgeTransferRequest, IList<KnowledgeTransfer>>
    {
        private readonly IRepository repository;
        public GetKnowledgeTransfer(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<KnowledgeTransfer> Handle(GetKnowledgeTransferRequest query)
        {
            return this.repository.Query<Entity.KnowledgeTransfer>().ProjectTo<KnowledgeTransfer>().ToList();            
        }
    }
}

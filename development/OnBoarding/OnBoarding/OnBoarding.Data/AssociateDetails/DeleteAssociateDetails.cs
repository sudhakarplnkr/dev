namespace OnBoarding.Data.AssociateDetails
{
    using System.Linq;
    using MediatR;
    using OnBoarding.Contract;
    using AutoMapper;
    using OnBoarding.Contract.Repository;
    public class DeleteAssociateDetails : IRequestHandler<DeleteAssociateDetailsRequest, Contract.DeleteAssociateDetails>
    {

        private readonly IRepository repository;
        private readonly IMapper mapper;

        public DeleteAssociateDetails(IRepository objRepository, IMapper objMapper)
        {
            this.repository = objRepository;
            this.mapper = objMapper;
        }

        public Contract.DeleteAssociateDetails Handle(DeleteAssociateDetailsRequest reqData)
        {
            var associate = repository.Query<Entities.Associate>().FirstOrDefault(i => i.Id == reqData.AssociateId && i.Active);
            associate.Active = false;
            repository.Update(associate);

            return new Contract.DeleteAssociateDetails();
        }

    }
}

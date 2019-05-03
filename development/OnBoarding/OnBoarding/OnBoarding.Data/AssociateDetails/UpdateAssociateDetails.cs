using AutoMapper;
using MediatR;
using OnBoarding.Contract;
using OnBoarding.Contract.Repository;
using System.Linq;
using Entity = OnBoarding.Entities;

namespace OnBoarding.Data
{
    public class UpdateAssociateDetails : IRequestHandler<UpdateAssociateDetailsRequest, Contract.UpdateAssociateDetails>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public UpdateAssociateDetails(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.UpdateAssociateDetails Handle(UpdateAssociateDetailsRequest command)
        {

            var associate = repository.Query<Entity.Associate>().FirstOrDefault(i => i.Id == command.AssociateDetails.AssociateId && i.Active);
            associate.Name = command.AssociateDetails.AssociateName;
            associate.ProjectId = command.AssociateDetails.ProjectId;
            associate.RoleId = command.AssociateDetails.CognizantRoleId;
            repository.Update(mapper.Map<Entity.Associate>(associate));


            var associateDetail = repository.Query<Entity.AssociateDetails>()
                .FirstOrDefault(i => i.Associate.Id == command.AssociateDetails.AssociateId && i.Associate.Active);
            
            var updatedAssociateDetail = mapper.Map<Entity.AssociateDetails>(command.AssociateDetails);
            repository.Update(mapper.Map(updatedAssociateDetail, associateDetail));

            return command.AssociateDetails;
        }
    }
}

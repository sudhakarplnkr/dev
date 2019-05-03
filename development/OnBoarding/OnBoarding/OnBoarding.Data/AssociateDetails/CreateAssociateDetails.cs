using AutoMapper;
using MediatR;
using OnBoarding.Contract;
using OnBoarding.Contract.Repository;
using Entity = OnBoarding.Entities;
using System;
using System.Linq;

namespace OnBoarding.Data.AssociateDetails
{
    public class CreateAssociateDetails : IRequestHandler<CreateAssociateDetailsRequest, Contract.AssociateDetails>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public CreateAssociateDetails(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Contract.AssociateDetails Handle(CreateAssociateDetailsRequest command)
        {
            var associate = new Entity.Associate
            {
                Id = Guid.NewGuid(),
                Active = true,
                Name = command.AssociateDetails.AssociateName,
                Code = command.AssociateDetails.CognizantId,
                ProjectId = command.AssociateDetails.ProjectId,
                RoleId = command.AssociateDetails.CognizantRoleId,
            };

            var normalRole = repository.Query<Entities.UserRole>().FirstOrDefault(u => u.Name == "Normal");
            if (normalRole != null)
            {
                repository.Save(mapper.Map(command.AssociateDetails, associate));
                command.AssociateDetails.AssociateId = associate.Id;
                this.repository.Save(mapper.Map<Entities.AssociateDetails>(command.AssociateDetails));

                var userRole = new Entities.AssociateUserRole
                {
                    AssociateId = associate.Id,
                    Id = Guid.NewGuid(),
                    UserRoleId = normalRole.Id
                };
                this.repository.Save(mapper.Map<Entities.AssociateUserRole>(userRole));
            }
            return new Contract.AssociateDetails();

        }
    }
}

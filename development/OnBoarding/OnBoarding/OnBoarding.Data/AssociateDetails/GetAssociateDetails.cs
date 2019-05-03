using AutoMapper;
using MediatR;
using OnBoarding.Contract;
using OnBoarding.Contract.Repository;
using System.Collections.Generic;
using System.Linq;
using Entity = OnBoarding.Entities;

namespace OnBoarding.Data
{
    public class GetAssociateDetails : IRequestHandler<GetAssociateDetailsByAssociateRequest, Response<IList<Contract.AssociateDetails>>>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public GetAssociateDetails(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Response<IList<Contract.AssociateDetails>> Handle(GetAssociateDetailsByAssociateRequest query)
        {
            var associates = (from associateDetail in repository.Query<Entity.AssociateDetails>()
                              join projectDetail in repository.Query<Entity.Project>()
                              on associateDetail.Associate.ProjectId equals projectDetail.Id
                              where (associateDetail.Associate.Active)
                              select new Contract.AssociateDetails
                              {
                                  CognizantId = associateDetail.Associate.Code,
                                  AssetNo = associateDetail.AssetNo,
                                  AssociateId = associateDetail.AssociateId,
                                  AssociateName = associateDetail.Associate.Name,
                                  Billable = associateDetail.Billable,
                                  CognizantRoleId = associateDetail.Associate.RoleId,
                                  ContactNo = associateDetail.ContactNo,
                                  DesignationId = associateDetail.DesignationId,
                                  Location = associateDetail.Location,
                                  Portfolio = associateDetail.Portfolio,
                                  ProjectId = associateDetail.Associate.ProjectId,
                                  FNZDateofJoining = associateDetail.FNZDateofJoining,
                                  FNZDateofLeaving = associateDetail.FNZDateofLeaving,
                                  FNZEmail = associateDetail.FNZEmail,
                                  FNZExperience = associateDetail.FNZExperience,
                                  FNZRoleId = associateDetail.FNZRoleId,
                                  FNZStaffId = associateDetail.FNZStaffId,
                                  FNZUserName = associateDetail.FNZUserName,
                                  TeamId = associateDetail.TeamId,
                                  VirtualMachineNo = associateDetail.VirtualMachineNo,
                                  CognizantEmailId = associateDetail.EmailId,
                                  ProjectName = projectDetail.Name,
                                  SkillSet = associateDetail.SkillSet,
                                  City = associateDetail.City,
                                  ExperienceOfAssociate = associateDetail.ExperienceOfAssociate,
                                  Fse = associateDetail.Fse,
                                  FseEligibility = associateDetail.FseEligibility
                                  
                              });
            var pageRecord = associates.Paginate(query.PageRequest);

            return new Response<IList<Contract.AssociateDetails>>
            {
                Result = pageRecord,
                TotalNumberOfRecords = associates.TotalCount(query.PageRequest)
            };
        }
    }
}

namespace OnBoarding.Data.AssociateDetails
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMissingTypeMaps = true;

            this.CreateMap<Entities.AssociateDetails, Contract.AssociateDetails>()
                .ForMember(dest => dest.CognizantId, opt => opt.MapFrom(o => o.Associate.Code))
                .ForMember(dest => dest.AssociateName, opt => opt.MapFrom(o => o.Associate.Name))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(o => o.Associate.ProjectId))
                .ForMember(dest => dest.CognizantRoleId, opt => opt.MapFrom(o => o.Associate.RoleId))
                .ForMember(dest => dest.CognizantEmailId, opt => opt.MapFrom(o => o.EmailId))
                .ForMember(dest => dest.City, opt => opt.MapFrom(o => o.City))
                .ForMember(dest => dest.SkillSet, opt => opt.MapFrom(o => o.SkillSet))
                .ForMember(dest => dest.Fse, opt => opt.MapFrom(o => o.Fse))
                .ForMember(dest => dest.ExperienceOfAssociate, opt => opt.MapFrom(o => o.ExperienceOfAssociate))
                .ForMember(dest => dest.FseEligibility, opt => opt.MapFrom(o => o.FseEligibility));

            this.CreateMap<Contract.UpdateAssociateDetails, Entities.AssociateDetails>()
                 .ForMember(dest => dest.EmailId, opt => opt.MapFrom(o => o.CognizantEmailId));
        }

    }
}

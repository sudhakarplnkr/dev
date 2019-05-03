namespace OnBoarding.Data.AssociateProject
{
    using AutoMapper;
    using Entity = OnBoarding.Entities;
    using Contract;
    using System;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMissingTypeMaps = true;

            this.CreateMap<CreateAssociateProject, Entity.AssociateProject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(o => true))
                .ForMember(dest => dest.Associate, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());

            this.CreateMap<UpdateAssociateProject, Entity.AssociateProject>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.Active, opt => opt.Ignore())
              .ForMember(dest => dest.Associate, opt => opt.Ignore())
              .ForMember(dest => dest.Project, opt => opt.Ignore())
              .ForMember(dest => dest.AssociateId, opt => opt.Ignore())
              .ForMember(dest => dest.ProjectId, opt => opt.Ignore());
        }
    }
}

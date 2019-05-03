namespace OnBoarding.Data.ProjectGroup
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

            CreateMap<CreateProjectGroup, Entity.ProjectGroup>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(o => true))
                .ForMember(dest => dest.Project, opt => opt.Ignore());

            this.CreateMap<UpdateProjectGroup, Entity.ProjectGroup>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.Active, opt => opt.Ignore())
              .ForMember(dest => dest.ProjectId, opt => opt.Ignore())
              .ForMember(dest => dest.Project, opt => opt.Ignore());

            CreateMap<Entities.ProjectTeam, Contract.Team>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => o.Team.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(o => o.Team.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(o => o.Team.Code));
        }
    }
}

namespace OnBoarding.Data.AssociateGroup
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

            this.CreateMap<CreateAssociateGroup, Entity.AssociateGroup>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(o => true))
                .ForMember(dest => dest.Associate, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectGroup, opt => opt.Ignore());
        }
    }
}

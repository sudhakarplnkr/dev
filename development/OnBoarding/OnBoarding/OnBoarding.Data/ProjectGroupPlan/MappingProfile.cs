namespace OnBoarding.Data.ProjectGroupPlan
{
    using AutoMapper;
    using Entity = OnBoarding.Entities;
    using Contract;
    using System;
    using System.Linq;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMissingTypeMaps = true;

            this.CreateMap<Entity.ProjectGroupPlan, ProjectGroupPlan>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(o => o.KnowledgeTransfer.Duration));

            this.CreateMap<Entity.ProjectGroupPlan, ProjectGroupPlanWithStatus>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(o => o.KnowledgeTransfer.Duration))
                .ForMember(dest => dest.CompletedCount, opt => opt.MapFrom(o => o.AssociatePlan.Count(i => i.Status)))
            .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(o => o.AssociatePlan.Count));

            this.CreateMap<CreateProjectGroupPlan, Entity.ProjectGroupPlan>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(o => true))
                .ForMember(dest => dest.KnowledgeTransfer, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectGroup, opt => opt.Ignore())
                .ForMember(dest => dest.Mode, opt => opt.Ignore())                
                .ForMember(dest => dest.Owner, opt => opt.Ignore());

            this.CreateMap<UpdateProjectGroupPlan, Entity.ProjectGroupPlan>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.Active, opt => opt.Ignore())
              .ForMember(dest => dest.ProjectGroupId, opt => opt.Ignore())
              .ForMember(dest => dest.ProjectGroup, opt => opt.Ignore())
              .ForMember(dest => dest.KnowledgeTransfer, opt => opt.Ignore())
              .ForMember(dest => dest.Mode, opt => opt.Ignore())              
              .ForMember(dest => dest.Owner, opt => opt.Ignore());

            this.CreateMap<Entity.AssociateUserRole, UserRole>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(o => o.UserRole.Name))
                .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(o => o.UserRoleId))
                .ForMember(dest => dest.RoleDescription, opt => opt.MapFrom(o => o.UserRole.Description));
        }
    }
}

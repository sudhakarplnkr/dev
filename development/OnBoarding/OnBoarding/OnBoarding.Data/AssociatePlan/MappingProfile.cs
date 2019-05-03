namespace OnBoarding.Data.AssociatePlan
{
    using AutoMapper;

    using Entity = OnBoarding.Entities;
    using Contract;
    using System;

    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMissingTypeMaps = true;

            this.CreateMap<Entity.AssociatePlan, AssociatePlan>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(x => x.ProjectGroupPlan.Owner.Name))
                .ForMember(dest => dest.ModeName, opt => opt.MapFrom(x => x.ProjectGroupPlan.Mode.Name))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(x => x.ProjectGroupPlan.Reference))
                .ForMember(dest => dest.KnowledgeTransferTitle, opt => opt.MapFrom(x => x.ProjectGroupPlan.KnowledgeTransfer.Name))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(x => x.ProjectGroupPlan.KnowledgeTransfer.Duration))
                .ForMember(dest => dest.Week, opt => opt.MapFrom(x => x.ProjectGroupPlan.Week))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(x => x.ProjectGroupPlan.Day))
                .ForMember(dest => dest.ScheduledDate, opt => opt.MapFrom(x => x.ProjectGroupPlan.ScheduledDate))
                .ForMember(dest => dest.ProofType, opt => opt.MapFrom(x => x.ProjectGroupPlan.Mode.ProofType))
                .ForMember(dest => dest.AssociateId, opt => opt.MapFrom(o => o.AssociateGroup.Associate.Id))
                .ForMember(dest => dest.AssociateCode, opt => opt.MapFrom(o => o.AssociateGroup.Associate.Code))
                .ForMember(dest => dest.AssociateName, opt => opt.MapFrom(o => o.AssociateGroup.Associate.Name));

            this.CreateMap<CreateAssociatePlan, Entity.AssociatePlan>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(o => true))
                .ForMember(dest => dest.AssociateGroup, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectGroupPlan, opt => opt.Ignore());

            this.CreateMap<UpdateAssociatePlan, Entity.AssociatePlan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Active, opt => opt.Ignore())
                .ForMember(dest => dest.AssociateGroup, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectGroupPlan, opt => opt.Ignore())
                .ForMember(dest => dest.AssociateGroupId, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectGroupPlanId, opt => opt.Ignore());
        }
    }
}

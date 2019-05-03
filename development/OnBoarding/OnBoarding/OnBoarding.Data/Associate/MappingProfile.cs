namespace OnBoarding.Data.Associate
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
        }
    }
}

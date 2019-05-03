namespace OnBoarding.Infrastructure
{
    using AutoMapper;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Data.Associate;
    using System;
    using System.Linq;

    public static class AutoMapperInstaller
    {
        public static void Install(IWindsorContainer container)
        {
            container.Register(
            Types.FromAssemblyContaining<MappingProfile>()
                .BasedOn<Profile>()
                .WithService.Base()
                .Configure(c => c.Named(c.Implementation.FullName))
                .LifestyleTransient());

            var profiles = container.ResolveAll<Profile>();

            var config = (Action<IMapperConfigurationExpression>)(con => profiles.ToList().ForEach(con.AddProfile));

            Mapper.Initialize(config);           

            container.Register(Component.For<IMapper>().UsingFactoryMethod(x =>
             {
                 return new MapperConfiguration(config).CreateMapper();
             }));

            // Mapper.Initialize(m => m.ConstructServicesUsing(container.Resolve));

            //// container.Register(Types.FromAssembly(Assembly.GetExecutingAssembly()).BasedOn<IValueResolver>());
            // container.Register(Types.FromAssemblyContaining<MappingProfile>().BasedOn<Profile>().WithServiceBase());
            // var profiles = container.ResolveAll<Profile>();
            // profiles.ToList().ForEach(p => Mapper.AddProfile(p));

            // container.Register(Component.For<IMapper>().Instance(Mapper));

            // container.AddFacility<TypedFactoryFacility>();

            // var config =(Action<IMapperConfigurationExpression>) (c =>
            // {
            //     foreach(var i in profiles)
            //     {
            //         c.AddProfile(i);
            //     }
            // });

            // container.Register(Component.For<IMapper>().UsingFactoryMethod(x =>
            // {
            //     return new MapperConfiguration(config).CreateMapper();
            // }));

            // Mapper.Initialize(config);
            //var myAssembly = Classes.FromAssemblyNamed("MyAssembly");

            //// Register AutoMapper such that it uses a singleton configuration
            //container.Register(
            //    //myAssembly.BasedOn(typeof(ITypeConverter<,>)).WithServiceSelf(),
            //    //myAssembly.BasedOn<AutoMapper.IValueResolver>().WithServiceBase(),
            //    myAssembly.BasedOn<Profile>().WithServiceBase(),
            //    Component.For<IEnumerable<IObjectMapper>>().UsingFactoryMethod(() => MapperRegistry.Mappers),
            //    Component.For<ConfigurationStore>()
            //        .LifestyleSingleton()
            //        .UsingFactoryMethod(x =>
            //        {
            //            var typeMapFactory = x.Resolve<ITypeMapFactory>();
            //            var mappers = x.Resolve<IEnumerable<IObjectMapper>>();
            //            ConfigurationStore configurationStore = new ConfigurationStore(typeMapFactory, mappers);
            //            configurationStore.ConstructServicesUsing(x.Resolve);
            //            configurationStore.AssertConfigurationIsValid();
            //            return configurationStore;
            //        }),
            //    Component.For<IConfigurationProvider>().UsingFactoryMethod(x => x.Resolve<ConfigurationStore>()),
            //    Component.For<IConfiguration>().UsingFactoryMethod(x => x.Resolve<ConfigurationStore>()),
            //    Component.For<IMappingEngine>().ImplementedBy<MappingEngine>().LifestyleSingleton(),
            //    Component.For<ITypeMapFactory>().ImplementedBy<TypeMapFactory>()
            //);

            //// Add all Profiles
            //var configuration = container.Resolve<IConfiguration>();
            //container.ResolveAll<Profile>().ToList().ForEach(configuration.AddProfile);
        }
    }
}

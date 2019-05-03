using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OnBoarding.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnBoarding.WebAPI.Installers
{
    public class OnBoardingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            EntityFrameworkInstaller.Install(container);
            MediatorInstaller.Install(container);
            AutoMapperInstaller.Install(container);
        }
    }
}
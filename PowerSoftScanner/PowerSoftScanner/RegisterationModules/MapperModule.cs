using AutoMapper;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.RegisterationModules
{
    public class MapperModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var config = new MapperConfiguration(cfg =>
            {
                var assimblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assmbly in assimblies)
                    cfg.AddMaps(assmbly);
            });

            var mapper = config.CreateMapper();
            containerRegistry.RegisterInstance(mapper);
        }
    }
}

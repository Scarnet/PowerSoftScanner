using Infrastructure.Interfaces;
using Infrastructure.Pipeline;
using Infrastructure.Providers;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.RegisterationModules
{
    public class CoreModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<INetworkProvider, NetworkProvider>();
            containerRegistry.Register<Pipeline>();
        }
    }
}

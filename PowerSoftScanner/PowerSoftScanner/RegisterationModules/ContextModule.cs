using PowerSoftScanner.Business.BusinessContexts;
using PowerSoftScanner.Business.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.RegisterationModules
{
    public class ContextModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IStockItemContext, StockItemContext>();
        }
    }
}

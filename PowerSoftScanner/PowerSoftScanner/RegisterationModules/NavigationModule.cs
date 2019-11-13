using PowerSoftScanner.Routes;
using PowerSoftScanner.ViewModels;
using PowerSoftScanner.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PowerSoftScanner.RegisterationModules
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(ScanRoutes.Navigation);
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(ScanRoutes.Main);
            containerRegistry.RegisterForNavigation<StoreListPage, StoreListPageViewModel>(ScanRoutes.StoreList);
            containerRegistry.RegisterForNavigation<StoreItemsListPage, StoreItemsListPageViewModel>(ScanRoutes.ItemsList);
            containerRegistry.RegisterForNavigation<ScanningPage, ScanningPageViewModel>(ScanRoutes.Scanning);
        }
    }
}

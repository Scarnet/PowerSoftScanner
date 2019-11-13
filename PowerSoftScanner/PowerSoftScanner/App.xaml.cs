using PowerSoftScanner.RegisterationModules;
using PowerSoftScanner.Routes;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PowerSoftScanner
{
    public partial class App : PrismApplication
    {
        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {

        }


        protected async override void OnInitialized()
        {
            InitializeComponent();
           var result =  await NavigationService.NavigateAsync($"/{ScanRoutes.Navigation}/{ScanRoutes.Main}");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<NavigationModule>();
            moduleCatalog.AddModule<ContextModule>();
            moduleCatalog.AddModule<CoreModule>();
            moduleCatalog.AddModule<MapperModule>();
            moduleCatalog.AddModule<BarcodeModule>();
        }

    }
}

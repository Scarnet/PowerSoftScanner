using Infrastructure.Interfaces;
using PowerSoftScanner.Barcode;
using PowerSoftScanner.Routes;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;
using ZXing.Net.Mobile.Forms;

namespace PowerSoftScanner.RegisterationModules
{
    public class BarcodeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IBarcodeScanProvider, BarcodeScanProvider>();
            var scanner = new ZXingScannerView()
            {
                AutomationId = "zxingScannerView",
            };

            var overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                AutomationId = "zxingDefaultOverlay",
            };

            containerRegistry.RegisterInstance(scanner);
            containerRegistry.RegisterInstance(overlay);
        }
    }
}

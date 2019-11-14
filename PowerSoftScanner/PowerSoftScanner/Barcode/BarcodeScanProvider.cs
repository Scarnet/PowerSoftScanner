using Infrastructure.Interfaces;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using PowerSoftScanner.Routes;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace PowerSoftScanner.Barcode
{
    public class BarcodeScanProvider : IBarcodeScanProvider
    {
        private INavigationService navigationService;
        private ZXingScannerView scanPage;
        public BarcodeScanProvider(INavigationService navigationService, ZXingScannerView scanPage)
        {
            this.navigationService = navigationService;
            this.scanPage = scanPage;
            InitScanningPage();
        }


        public event EventHandler<string> BarcodeScanned;

        public async Task StartScanning()
        {
            await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
            await this.navigationService.NavigateAsync($"/{ScanRoutes.Scanning}");
        }

        private void InitScanningPage()
        {
            this.scanPage.OnScanResult += HandleScabResult;
        }

        private async void HandleScabResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () => await this.navigationService.NavigateAsync($"/{ScanRoutes.Navigation}/{ScanRoutes.Main}"));
            BarcodeScanned?.Invoke(this.scanPage, result.Text);
        }
    }
}

using Infrastructure.Interfaces;
using PowerSoftScanner.Routes;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace PowerSoftScanner.Barcode
{
    public class BarcodeScanProvider : IBarcodeScanProvider
    {
        private INavigationService navigationService;
        private ZXingScannerPage scanPage;
        public BarcodeScanProvider(INavigationService navigationService, ZXingScannerPage scanPage)
        {
            this.navigationService = navigationService;
            this.scanPage = scanPage;
            InitScanningPage();
        }


        public event EventHandler<string> BarcodeScanned;

        public async Task StartScanning()
        {
            await this.navigationService.NavigateAsync(ScanRoutes.Scanning);
        }

        private void InitScanningPage()
        {
            this.scanPage.OnScanResult += HandleScabResult;
        }

        private void HandleScabResult(Result result)
        {
            BarcodeScanned?.Invoke(this.scanPage, result.Text);
        }
    }
}

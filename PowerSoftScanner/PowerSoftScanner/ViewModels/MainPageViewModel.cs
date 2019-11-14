using Infrastructure.Interfaces;
using PowerSoftScanner.Abstracts;
using PowerSoftScanner.Business.Interfaces;
using PowerSoftScanner.Dictionairies;
using PowerSoftScanner.Routes;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PowerSoftScanner.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        IBarcodeScanProvider barcodeScanProvider;
        IStockItemContext stockItemContext;
        public MainPageViewModel(IBarcodeScanProvider barcodeScanProvider, INavigationService navigationService,
            IStockItemContext stockItemContext) : base(navigationService)
        {
            this.barcodeScanProvider = barcodeScanProvider;
            this.barcodeScanProvider.BarcodeScanned += HandleScanResults;
            this.stockItemContext = stockItemContext;
        }


        #region Commands
        public DelegateCommand ScanCommand => new BaseCommandHandler(HandleScan);
        public DelegateCommand<string> GetItemsCommand => new BaseCommandHandler<string>(async (barcode)=> await HandleGetItems(barcode));


        #endregion


        private void HandleScan()
        {
           this.barcodeScanProvider.StartScanning();
        }

        private void HandleScanResults(object sender, string barcode)
        {
            GetItemsCommand.Execute(barcode);

        }

        private async Task HandleGetItems(string barcode)
        {
            ShowLoading(Resources.Resources.GettingData);
            var stockItems = await this.stockItemContext.GetStockItem(barcode);
            var parameters = new NavigationParameters();
            parameters.Add(ParametersDictionairy.StockItems, stockItems);
            Device.BeginInvokeOnMainThread(async () => 
                await NavigationService.NavigateAsync($"/{ScanRoutes.Navigation}/{ScanRoutes.StoreList}", parameters)
            );
            HideLoading();
        }



    }
}

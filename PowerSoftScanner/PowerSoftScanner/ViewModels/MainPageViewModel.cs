using Infrastructure.Interfaces;
using PowerSoftScanner.Abstracts;
using PowerSoftScanner.Business.Interfaces;
using PowerSoftScanner.Routes;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DelegateCommand<string> GetItemsCommand => new BaseCommandHandler<string>(HandleGetItems);


        #endregion


        private void HandleScan()
        {
           this.barcodeScanProvider.StartScanning();
        }

        private void HandleScanResults(object sender, string barcode)
        {
            GetItemsCommand.Execute(barcode);

        }

        private void HandleGetItems(string barcode)
        {
            var stockItems = this.stockItemContext.GetStockItem(barcode);
            var parameters = new NavigationParameters();
            parameters.Add("Items", stockItems);
            NavigationService.NavigateAsync($"/{ScanRoutes.StoreList}");
        }



    }
}

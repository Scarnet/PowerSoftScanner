using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using PowerSoftScanner.Abstracts;
using PowerSoftScanner.Business.Models.Business;
using PowerSoftScanner.Dictionairies;
using PowerSoftScanner.Models;
using PowerSoftScanner.Routes;
using Prism.Commands;
using Prism.Navigation;

namespace PowerSoftScanner.ViewModels
{
    public class StoreListPageViewModel : BaseViewModel
    {
        #region
        private ObservableCollection<Store> stores;
        public ObservableCollection<Store> Stores
        {
            get => stores;
            set => SetProperty(ref stores, value);
        }
        private Store selectedStore;
        public Store SelectedStore
        {
            get => selectedStore;
            set => SetProperty(ref selectedStore, value, SelectedStoreChanged);
        }
        #endregion

        #region Commands
        public DelegateCommand ScanCommand => new BaseCommandHandler(() => NavigationService.NavigateAsync($"/{ScanRoutes.Navigation}/{ScanRoutes.Main}"));
        #endregion
        public StoreListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var stockItems = (List<StockItem>)parameters[ParametersDictionairy.StockItems];
            var stores = stockItems.GroupBy(i => new { i.StoreCode, i.StoreName })
                .Select(g => new Store() { Name = g.Key.StoreName, Code = g.Key.StoreCode, Items = g.ToList() });

            Stores = new ObservableCollection<Store>(stores.ToList());
        }

        private async void SelectedStoreChanged()
        {
            var parameters = new NavigationParameters();
            parameters.Add(ParametersDictionairy.StockItems, this.selectedStore.Items);
            parameters.Add(ParametersDictionairy.StoreName, this.SelectedStore.Name);
            await NavigationService.NavigateAsync(ScanRoutes.ItemsList, parameters);
        }

    }
}

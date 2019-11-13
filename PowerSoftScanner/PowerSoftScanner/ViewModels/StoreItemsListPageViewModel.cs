using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PowerSoftScanner.Abstracts;
using PowerSoftScanner.Business.Models.Business;
using PowerSoftScanner.Dictionairies;
using PowerSoftScanner.Routes;
using Prism.Commands;
using Prism.Navigation;

namespace PowerSoftScanner.ViewModels
{
    public class StoreItemsListPageViewModel : BaseViewModel
    {
        #region
        private ObservableCollection<StockItem> items;
        public ObservableCollection<StockItem> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private string storeName;
        public string StoreName
        {
            get => storeName;
            set => SetProperty(ref storeName, value);
        }
        #endregion

        #region Commands
        public DelegateCommand ScanCommand => new BaseCommandHandler(() => NavigationService.NavigateAsync($"/{ScanRoutes.Navigation}/{ScanRoutes.Main}"));
        #endregion

        public StoreItemsListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var items = (List<StockItem>)parameters[ParametersDictionairy.StockItems];
            var storeName = parameters[ParametersDictionairy.StoreName];
            Items = new ObservableCollection<StockItem>(items);
            StoreName = storeName.ToString();
        }


    }
}

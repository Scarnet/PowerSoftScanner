using Acr.UserDialogs;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerSoftScanner.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        protected INavigationService NavigationService;

        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        protected void ShowLoading(string msg = "")
        {
            UserDialogs.Instance.ShowLoading(msg);
        }

        protected void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}

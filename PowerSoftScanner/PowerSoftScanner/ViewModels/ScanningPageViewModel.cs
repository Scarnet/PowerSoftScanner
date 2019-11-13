using System;
using System.Collections.Generic;
using System.Text;
using PowerSoftScanner.Abstracts;
using PowerSoftScanner.Routes;
using Prism.Commands;
using Prism.Navigation;

namespace PowerSoftScanner.ViewModels
{
    public class ScanningPageViewModel : BaseViewModel
    {
        public DelegateCommand CloseCommand => new BaseCommandHandler(() => NavigationService.NavigateAsync($"/{ScanRoutes.Navigation}/{ScanRoutes.Main}"));
        public ScanningPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }


    }
}

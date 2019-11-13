using PowerSoftScanner.Routes;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace PowerSoftScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanningPage : ContentPage
    {
        private ZXingScannerView scanner;
        public ScanningPage(ZXingScannerView scanner, ZXingDefaultOverlay overlay)
        {
            InitializeComponent();
            this.scanner = scanner;
            mainGrid.Children.Insert(0, overlay);
            mainGrid.Children.Insert(0, scanner);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.scanner.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            this.scanner.IsScanning = false;
            base.OnDisappearing();
        }
    }
}
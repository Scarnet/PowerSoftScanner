using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBarcodeScanProvider
    {
        Task StartScanning();
        event EventHandler<string> BarcodeScanned;
    }
}

using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerSoftScanner
{
    public static class ExceptionHandler
    {
        public static async Task Handle(Exception ex)
        {
            UserDialogs.Instance.HideLoading();
            await UserDialogs.Instance.AlertAsync(ex.Message, "Error");
        }
    }
}

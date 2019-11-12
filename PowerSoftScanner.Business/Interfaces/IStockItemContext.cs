using PowerSoftScanner.Business.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerSoftScanner.Business.Interfaces
{
    public interface IStockItemContext
    {
        Task<List<StockItem>> GetStockItem(string code);

    }
}

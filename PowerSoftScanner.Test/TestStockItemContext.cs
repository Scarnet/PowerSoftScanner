using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Pipeline;
using Infrastructure.Providers;
using NUnit.Framework;
using PowerSoftScanner.Business.BusinessContexts;
using PowerSoftScanner.Business.Exceptions;
using PowerSoftScanner.Business.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    public class TestStockItemContext
    {
        IStockItemContext stockItemContext;
        [SetUp]
        public void Setup()
        {
            INetworkProvider networkProvider = new NetworkProvider();

            var config = new MapperConfiguration(cfg =>
            {
                var assimblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assmbly in assimblies)
                    cfg.AddMaps(assmbly);
            });

            var mapper = config.CreateMapper();

            var pipeLine = new Pipeline();
            stockItemContext = new StockItemContext(networkProvider, mapper, pipeLine);
        }

        [Test]
        public async Task TestStockItem()
        {
            var item = await stockItemContext.GetStockItem("ADID465-TEST");
            Assert.IsTrue(item.Any());
        }

        [Test]
        public void TestItemNotFound()
        {
            var item =
            Assert.Catch( () =>  stockItemContext.GetStockItem("ADID465-TESTttt").Wait());
        }
    }
}


    
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using RefactorMe.DontRefactor.Models;
using RefactorMe.Services;
using RefactorMe.Services.impl;
using System.Collections.Generic;

namespace RefactorMe.Tests.Services
{
    [TestClass]
    public class ConsolidatorServiceTest
    {

        [TestMethod]
        public void TestDefaultCurrency()
        {
            var cs = new ConsolidatorService();
            cs.CurrencyManager = GetMockedCurrencyManager("NZD", 1.33);
            cs.CurrencyManager.GetAllNames();
            cs.CurrencyManager.Exchange("NZD", 33);
            IConsolidatorService service = cs;

            Assert.AreEqual(service.GetCurrencyNames()[0], "NZD");

            var list = service.GetProductList("NZD", ListOrder.Default);
            Assert.IsInstanceOfType(list, typeof(List<Product>));
        }


        public void TestGetAllListOrderBy()
        {
            IConsolidatorService service = new ConsolidatorService();

            var list = service.GetProductList(null, ListOrder.Name, false);
            var listDesc = service.GetProductList(null, ListOrder.Name, true);
            Assert.AreSame(list[0], list[list.Count]);

            list = service.GetProductList(null, ListOrder.Price, false);
            listDesc = service.GetProductList(null, ListOrder.Price, true);
            Assert.AreSame(list[0], list[list.Count]);
        }

        private dynamic GetMockedCurrencyManager(string name, double rate)
        {
            var mock = Mock.Create<ICurrencyManager>();
            Mock.Arrange(() => mock.GetAllNames()).Returns(() => new List<string>() { name });
            Mock.Arrange(()=>mock.Exchange(Arg.IsAny<string>(), Arg.IsAny<double>()))
                .Returns((string x,double y)=>y*rate);
            return mock;
        }
    }
}


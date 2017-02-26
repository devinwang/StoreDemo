using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Collections.Generic;
using RefactorMe.Controllers;
using RefactorMe.Models;
using RefactorMe.Services.impl;
using RefactorMe.DontRefactor.Models;
using Telerik.JustMock;
using RefactorMe.Services;

namespace RefactorMe.Tests.Controllers
{
    [TestClass]
    public class ApiControllerTest
    {
        [TestMethod]
        public void TestGetProductList()
        {
            // string orderby, int desc, int pageSize, int pageNumber
            // Arrange
            ApiController controller = new ApiController();
            ConsolidatorService cs = new ConsolidatorService();
            cs.CurrencyManager = GetMockedCurrencyManager("NZD", 1.33);
            controller.service = cs;

            JsonResult result = controller.GetProductList("", 1, false) as JsonResult;
            Assert.IsNotNull(result);

            result = controller.GetProductList("", 1, true) as JsonResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestGetCurrencyList()
        {
            ApiController controller = new ApiController();
            ConsolidatorService cs = new ConsolidatorService();
            cs.CurrencyManager = GetMockedCurrencyManager("NZD", 1.33);
            controller.service = cs;

            JsonResult result = controller.GetCurrencyList() as JsonResult;
            Assert.IsNotNull(result);
        }

        private dynamic GetMockedCurrencyManager(string name, double rate)
        {
            var mock = Mock.Create<ICurrencyManager>();
            Mock.Arrange(() => mock.GetAllNames()).Returns(() => new List<string>() { name });
            Mock.Arrange(() => mock.Exchange(Arg.IsAny<string>(), Arg.IsAny<double>()))
                .Returns((string x, double y) => y * rate);
            return mock;
        }
    }
}

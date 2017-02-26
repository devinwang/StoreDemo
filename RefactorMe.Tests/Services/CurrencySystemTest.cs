using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using RefactorMe.Services;
using RefactorMe.Services.impl;

namespace RefactorMe.Tests.Services
{
    /// <summary>
    /// Summary description for CurrencySystemTest
    /// </summary>
    [TestClass]
    public class CurrencySystemTest
    {
        [TestMethod]
        public void TestCurrencyManagerEnumerable()
        {
            ICurrencyManager manager = new SimpleCurrencyManager();
            var enumerator = manager.GetEnumerator();
            Assert.IsInstanceOfType(enumerator, typeof(IEnumerator<ICurrency>));
        }

        [TestMethod]
        public void TestCurrencyManagerExchange()
        {
            ICurrencyManager manager = new SimpleCurrencyManager();
            Assert.IsNull(manager.Exchange("____No exist!!!", 128.32));
        }

        [TestMethod]
        public void TestCurrencyManagerGetAllNames()
        {
            ICurrencyManager manager = new SimpleCurrencyManager();
            Assert.IsInstanceOfType(manager.GetAllNames(), typeof(List<String>));
        }

        [TestMethod]
        public void TestCurrency()
        {
            ICurrency currency = new Currency("USD", 1.0d);
            Assert.AreEqual(currency.GetName(), "USD");
            Assert.AreEqual(currency.GetRate(), 1.0d);
            Assert.AreEqual(currency.Exchange(1.2d), 1.2d);

            currency = new Currency("NZD", 1.3d);
            Assert.AreEqual(currency.GetName(), "NZD");
            Assert.AreEqual(currency.GetRate(), 1.3d);
            Assert.AreEqual(currency.Exchange(1.2d), 1.2d * 1.3d);
        }

    }
}

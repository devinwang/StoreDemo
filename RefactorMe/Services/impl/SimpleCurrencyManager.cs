using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefactorMe.Services.impl
{
    public class SimpleCurrencyManager : ICurrencyManager
    {
        private List<ICurrency> currencies = new List<ICurrency>()
        {
            new Currency("USD", 1.0d),
            new Currency("NZD", 1.3d),
            new Currency("EURO", 0.8d),
        };
 
        public double? Exchange(string name, double price)
        {
            if (name == null)
                return null;
            ICurrency currency = currencies.Where(x => x.GetName() == name.ToUpper()).
                FirstOrDefault();
            if (currency == null)
                return null;
            return currency.Exchange(price);
        }

        public List<string> GetAllNames()
        {
            return currencies.Select(x => x.GetName()).ToList();
        }

        public IEnumerator<ICurrency> GetEnumerator()
        {
            return currencies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return currencies.GetEnumerator();
        }
    }
}
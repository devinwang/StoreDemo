using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefactorMe.Services
{
    public interface IConsolidatorService
    {
        List<Product> GetProductList(string currencyName, ListOrder order, bool desc=false);
        List<String> GetCurrencyNames();

    }
}
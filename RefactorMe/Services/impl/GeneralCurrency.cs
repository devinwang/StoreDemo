using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RefactorMe.Services;

namespace RefactorMe.Services.impl
{
    public abstract class GeneralCurrency : ICurrency
    {
        protected double rate;
        protected string name;

        public string GetName()
        {
            return name;
        }

        public double GetRate()
        {
            return rate;
        }

        public double Exchange(double price)
        {
            return price * rate;
        }
    }
}
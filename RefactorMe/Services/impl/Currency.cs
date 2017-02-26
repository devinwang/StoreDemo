using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefactorMe.Services.impl
{
    public class Currency : GeneralCurrency
    {
        public Currency(string name, double rate)
        {
            this.name = name;
            this.rate = rate;
        }
    }
}
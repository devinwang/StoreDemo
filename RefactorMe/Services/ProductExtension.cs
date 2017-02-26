using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefactorMe.Services
{
    public static class ProductExtension
    {
        // Using double type for money is not a good idea, so convert to decimal 
        public static decimal DecimalPrice(this Product product)
        {
            return Convert.ToDecimal(product.Price);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Services
{
    public interface ICurrencyManager : IEnumerable<ICurrency>
    {
        List<String> GetAllNames();
        double? Exchange(string name, double price);
    }
}

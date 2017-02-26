using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Services
{
    public interface ICurrency
    {
        string GetName();
        double GetRate();
        double Exchange(double price);
    }
}

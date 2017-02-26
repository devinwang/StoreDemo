using System;
using System.Collections.Generic;
using RefactorMe.DontRefactor.Models;
using RefactorMe.Services;
using RefactorMe.DontRefactor.Data.Implementation;
using System.Linq;
using RefactorMe.Models;
using Microsoft.Practices.Unity;

namespace RefactorMe.Services.impl
{
    public class ConsolidatorService : IConsolidatorService
    {
        [Dependency]
        public ICurrencyManager CurrencyManager { get; set; }

        public List<string> GetCurrencyNames()
        {
            return CurrencyManager.GetAllNames();
        }

        public List<Product> GetProductList(string currencyName, ListOrder order, bool desc)
        {
            if (CurrencyManager.Exchange(currencyName, 1.0d) == null)
            {
                // Currency is not exist 
                return null;
            }

            var query = lawnmowerRepo.GetAll().Select(x => new Product()
            {
                Id = x.Id,
                Price = (double)CurrencyManager.Exchange(currencyName, x.Price),
                Name = x.Name,
                Type = "Lawnmower"
            })
            .Union(
              phonecaseRepo.GetAll().Select(x => new Product()
              {
                  Id = x.Id,
                  Price = (double)CurrencyManager.Exchange(currencyName, x.Price),
                  Name = x.Name,
                  Type = "Phone Case"
              }))
              .Union(
                tshirtRepo.GetAll().Select(x => new Product()
                {
                    Id = x.Id,
                    Price = (double)CurrencyManager.Exchange(currencyName, x.Price),
                    Name = x.Name,
                    Type = "T-Shirt"
                })
                );

            switch (order)
            {
                case ListOrder.Id:
                    return desc ? query.OrderByDescending(x => x.Id).ToList()
                        : query.OrderBy(x => x.Id).ToList();
                case ListOrder.Name:
                    return desc ? query.OrderByDescending(x => x.Name).ToList()
                        : query.OrderBy(x => x.Name).ToList();
                case ListOrder.Price:
                    return desc ? query.OrderByDescending(x => x.Price).ToList()
                        : query.OrderBy(x => x.Price).ToList();
                case ListOrder.Type:
                    return desc ? query.OrderByDescending(x => x.Type).ToList()
                        : query.OrderBy(x => x.Type).ToList();
                default:
                    return query.ToList();
            }
        }
        private BaseReadOnlyRepository<Lawnmower> lawnmowerRepo = new LawnmowerRepository();
        private BaseReadOnlyRepository<PhoneCase> phonecaseRepo = new PhoneCaseRepository();
        private BaseReadOnlyRepository<TShirt> tshirtRepo = new TShirtRepository();
    }
}
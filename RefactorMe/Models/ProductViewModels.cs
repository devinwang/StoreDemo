using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RefactorMe.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
    }
}

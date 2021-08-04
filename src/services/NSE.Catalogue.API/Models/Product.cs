using System;
using NSE.Core.DomainObject;

namespace NSE.Catalogue.API.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public DateTime AddAt { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }

    }
}

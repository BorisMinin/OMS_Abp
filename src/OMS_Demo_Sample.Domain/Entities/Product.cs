using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class Product : Entity<int>
    {
        public string ProductName { get; set; }

        public Category Category { get; set; }

        public int? CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public double? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public int? UnitsOnOrder { get; set; }

        public int? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
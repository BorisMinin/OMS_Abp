using OMS_Demo_Sample.CustomAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.Domain.Entities.Auditing;

namespace OMS_Demo_Sample.Entities
{
    public class Product : FullAuditedAggregateRoot<int>
    {
        private Product()
        {
            
        }

        internal Product(
            [StartsWith (1)]
            int id,

            [NotNull] [MaxLength (100)]
            string productName,

            [NotNull] [MaxLength (25)]
            Category category
            ) : base(id)
        {
            ProductName = productName;
            Category = category;
        }

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
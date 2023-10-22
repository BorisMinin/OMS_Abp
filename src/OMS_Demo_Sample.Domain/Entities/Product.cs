using JetBrains.Annotations;
using OMS_Demo_Sample.Entities.Helpers;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class Product : Entity<int>
    {
        private Product() {}

        internal Product(
            int id,
            [NotNull][StringLength(40)] string productName,
            int categoryId,
            [CanBeNull] string quantityPerUnit,
            double unitPrice,
            short unitsInStock,
            short unitsOnOrder,
            short reorderLevel,
            bool discontinued
            ) : base(id)
        {
            EntityUtilsHelper.SetEntityName(productName);
            CategoryId = categoryId;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
        }
        [Required]
        [StringLength(40)]
        public string ProductName { get; private set; }

        public int? CategoryId { get; private set; }

        [StringLength(40)]
        public string QuantityPerUnit { get; set; }

        public double? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public int? UnitsOnOrder { get; set; }

        public int? ReorderLevel { get; set; }

        public bool? Discontinued { get; set; }
    }
}
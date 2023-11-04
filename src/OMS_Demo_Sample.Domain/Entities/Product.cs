using JetBrains.Annotations;
using OMS_Demo_Sample.Entities.Products;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class Product : Entity<int>
    {
        private Product() {}

        internal Product(
            int id,
            [NotNull] [StringLength(ProductConsts.MaxProductNameLength)] string productName,
            [NotNull] int categoryId,
            [NotNull] [StringLength(ProductConsts.MaxQuantityPerUnit)] string quantityPerUnit
            ) : base(id)
        {
            SetProductName(productName);
            CategoryId = categoryId;
            QuantityPerUnit = quantityPerUnit;
        }
        [Required]
        [StringLength(ProductConsts.MaxProductNameLength)] public string ProductName { get; private set; }

        public int? CategoryId { get; private set; }

        [StringLength(ProductConsts.MaxQuantityPerUnit)] 
        public string QuantityPerUnit { get; set; }

        public double? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public int? UnitsOnOrder { get; set; }

        public int? ReorderLevel { get; set; }

        public bool? Discontinued { get; set; }

        internal Product ChangeProductName(string productName)
        {
            SetProductName(productName);
            return this;
        }

        public void SetProductName(string productName)
        {
            ProductName = Check.NotNullOrWhiteSpace(
                productName,
                nameof(productName),
                maxLength: ProductConsts.MaxProductNameLength); 
        }
    }
}
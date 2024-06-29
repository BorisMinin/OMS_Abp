#nullable enable
using OMS_Abp.Entities.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OMS_Abp.Domain.Entities;

public class Product : Entity<int>
{
    private Product() { }

    internal Product(
        int id,
        [NotNull][StringLength(ProductConsts.MaxProductNameLength)] string productName,
        [NotNull] int categoryId,
        [NotNull][StringLength(ProductConsts.MaxQuantityPerUnit)] string quantityPerUnit
        ) : base(id)
    {
        SetProductName(productName);
        CategoryId = categoryId;
        QuantityPerUnit = quantityPerUnit;
    }

    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public string? QuantityPerUnit { get; set; }

    public double? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier? Supplier { get; set; }

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
#nullable enable
using OMS_Abp.Entities.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OMS_Abp.Domain.Entities;

public class Category : Entity<int>
{
    private Category() { }

    internal Category(
        int id,
        [NotNull] [StringLength(CategoryConsts.MaxCategoryNameLength)]
            string categoryName)
    : base(id)
    {
        SetCategoryName(categoryName);
    }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    internal Category ChangeName([NotNull][StringLength(CategoryConsts.MaxCategoryNameLength)] string categoryName)
    {
        SetCategoryName(categoryName);
        return this; // возврат текущего экземпляра объекта
    }

    private void SetCategoryName(string categoryName)
    {
        CategoryName = Check.NotNullOrWhiteSpace(
            categoryName,
            nameof(categoryName),
            maxLength: CategoryConsts.MaxCategoryNameLength);
    }
}
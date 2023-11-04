using JetBrains.Annotations;
using OMS_Demo_Sample.Entities.Categories;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
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

        [Required]
        [StringLength(CategoryConsts.MaxCategoryNameLength)]
        public string CategoryName { get; private set; }
        public string? Description { get; set; }

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
}
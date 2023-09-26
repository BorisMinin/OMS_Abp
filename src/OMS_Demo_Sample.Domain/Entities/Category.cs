using JetBrains.Annotations;
using OMS_Demo_Sample.CustomAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace OMS_Demo_Sample.Entities
{
    /// <summary>
    /// Бизнес правила для id:
    /// 1. id не может быть null
    /// 2. id не может быть пустой строкой
    /// 3. id не может быть равно 0
    /// 4. id не может иметь значение равное числу с плавающей точкой
    /// 5. id должно иметь тип int
    /// </summary>
    public class Category : FullAuditedAggregateRoot<int>
    {
        private Category()
        {

        }

        internal Category(
            [StartsWith (1)]
            int id,
            [NotNull] [MaxLength (25)] string categoryName,
            [CanBeNull] string description = null)
        : base(id)
        {

        }

        public string CategoryName { get; private set; }
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
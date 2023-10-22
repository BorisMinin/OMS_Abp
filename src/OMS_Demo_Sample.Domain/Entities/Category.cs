using JetBrains.Annotations;
using OMS_Demo_Sample.Entities.Helpers;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class Category : Entity<int>
    {
        private Category() {}

        internal Category(
            int id,
            [NotNull][StringLength(15)] string categoryName,
            string? description = null)
        : base(id)
        {
            EntityUtilsHelper.SetEntityName(categoryName);
            Description = description;
        }
        [Required] 
        [StringLength(15)]
        public string CategoryName { get; private set; }
        public string? Description { get; set; }
    }
}
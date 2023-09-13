using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class Category : Entity<int>
    {
        public string CategoryName { get; private set; }
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
using System.Collections.Generic;
using System;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class Order : Entity<int>
    {
        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public decimal? Freight { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
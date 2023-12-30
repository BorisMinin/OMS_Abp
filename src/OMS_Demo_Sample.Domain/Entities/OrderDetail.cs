using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class OrderDetail : Entity
    {
        public OrderDetail(
            int orderId,
            int productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Column(TypeName = "money")]
        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public float Discount { get; set; }

        public override object[] GetKeys()
        {
            return [OrderId, ProductId];
        }
    }
}
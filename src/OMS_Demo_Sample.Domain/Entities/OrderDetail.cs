using System.ComponentModel.DataAnnotations.Schema;

namespace OMS_Demo_Sample.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Column(TypeName = "money")]
        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public float Discount { get; set; }
    }
}
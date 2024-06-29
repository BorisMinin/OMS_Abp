#nullable enable
using Volo.Abp.Domain.Entities;

namespace OMS_Abp.Domain.Entities;

public class OrderDetail : Entity
{
    private OrderDetail() { }

    public OrderDetail(
        int orderId,
        int productId)
    {
        OrderId = orderId;
        ProductId = productId;
    }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public double UnitPrice { get; set; }

    public short Quantity { get; set; }

    public double Discount { get; set; }

    public override object[] GetKeys()
    {
        return [OrderId, ProductId];
    }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
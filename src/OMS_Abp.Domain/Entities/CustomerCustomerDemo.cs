#nullable enable
namespace OMS_Abp.Domain.Entities;

public class CustomerCustomerDemo
{
    public string CustomerId { get; set; } = null!;

    public string CustomerTypeId { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomerDemographic CustomerType { get; set; } = null!;
}
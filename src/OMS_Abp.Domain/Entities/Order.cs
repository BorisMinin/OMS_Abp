#nullable enable
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace OMS_Abp.Domain.Entities;

public class Order : AggregateRoot<int>
{
    private Order() { }

    public Order(
        int id,
        int? employeeId,
        string? customerId,
        double freight,
        DateTime requiredDate
        ) : base(id)
    {
        EmployeeId = employeeId;
        CustomerId = customerId;
        Freight = freight;
        OrderDate = DateTime.Now;
        RequiredDate = requiredDate;
    }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public double? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Shipper? ShipViaNavigation { get; set; }
}
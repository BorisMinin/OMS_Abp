#nullable enable
using OMS_Abp.Entities.Customers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OMS_Abp.Domain.Entities;

public class Customer : Entity<string>
{
    private Customer() { }

    internal Customer(
        [NotNull] [StringLength(CustomerConsts.MaxCustomerIdLength)]
            string customerId,
        [NotNull] [StringLength(CustomerConsts.MaxCompanyNameLength)]
            string companyName)
        : base(customerId)
    {
        SetCompanyName(companyName);
    }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemos { get; set; } = new List<CustomerCustomerDemo>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    private void SetCompanyName(string companyName)
    {
        CompanyName = Check.NotNullOrWhiteSpace(
            companyName,
            nameof(companyName),
            maxLength: CustomerConsts.MaxCompanyNameLength);
    }
}
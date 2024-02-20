using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using System.Diagnostics.CodeAnalysis;
using OMS_Abp.Entities.Customers;
using Volo.Abp;

namespace OMS_Abp.Entities
{
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

        [Required]
        [StringLength(CustomerConsts.MaxCompanyNameLength)]
        public string CompanyName { get; set; }
        [StringLength(CustomerConsts.MaxContactNameLength)]
        public string ContactName { get; set; }
        [StringLength(CustomerConsts.MaxContactTitleLength)]
        public string ContactTitle { get; set; }
        [StringLength(CustomerConsts.MaxAddressLength)]
        public string Address { get; set; }
        [StringLength(CustomerConsts.MaxCityLength)]
        public string City { get; set; }
        [StringLength(CustomerConsts.MaxRegionLength)]
        public string Region { get; set; }
        [StringLength(CustomerConsts.MaxPostalCodeLength)]
        public string PostalCode { get; set; }
        [StringLength(CustomerConsts.MaxCountryLength)]
        public string Country { get; set; }
        [StringLength(CustomerConsts.MaxPhoneLength)]
        public string Phone { get; set; }
        [StringLength(CustomerConsts.MaxFaxLength)]
        public string Fax { get; set; }

        public ICollection<Order> Orders { get; set; }

        private void SetCompanyName(string companyName)
        {
            CompanyName = Check.NotNullOrWhiteSpace(
                companyName,
                nameof(companyName),
                maxLength: CustomerConsts.MaxCompanyNameLength);
        }
    }
}
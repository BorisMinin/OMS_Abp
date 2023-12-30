using JetBrains.Annotations;
using OMS_Demo_Sample.Entities.Shippers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class Shipper : Entity<int>
    {
        private Shipper() { }

        internal Shipper(
            int shipperId,
            [NotNull] [StringLength(ShipperConsts.MaxCompanyNameLength)]
            string CompanyName,
            [NotNull] [StringLength(ShipperConsts.MaxPhoneLength)]
            string phone
            )
        {
            SetCompanyName(CompanyName);
            SetPhone(phone);
        }

        [StringLength(ShipperConsts.MaxCompanyNameLength)]
        public string CompanyName { get; set; }
        [StringLength(ShipperConsts.MaxPhoneLength)]
        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }

        private void SetCompanyName(string CompanyName)
        {
            CompanyName = Check.NotNullOrWhiteSpace(
                CompanyName,
                nameof(CompanyName),
                maxLength: ShipperConsts.MaxCompanyNameLength);
        }

        private void SetPhone(string phone)
        {
            Phone = Check.NotNullOrWhiteSpace(
                phone,
                nameof(phone),
                maxLength: ShipperConsts.MaxPhoneLength);
        }
    }
}
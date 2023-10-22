using System.Collections.Generic;
using System;
using Volo.Abp.Domain.Entities;

namespace OMS_Demo_Sample.Entities
{
    public class Order : AggregateRoot<int>
    {
        private Order() { }

        public Order(
            int id,
            int employeeId,
            string? customerId = null


            ) : base(id)
        {

        }

        public int EmployeeId { get; private set; }

        public string? CustomerId { get; private set; }

        public double Freight { get; }

        public DateTime OrderDate { get; private set; }

        public DateTime RequiredDate { get; set; }

        public string? ShipName { get; set; }

        public string? ShipAddress { get; set; }

        public string? ShipRegion { get; set; }

        public string? ShipCity { get; set; }

        public string? ShipPostalCode { get; set; }

        public string? ShipCountry { get; set; }
    }
}
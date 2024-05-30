using OMS_Abp.Entities.Eemployees;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OMS_Abp.Entities
{
    public class Employee : Entity<int>
    {
        public Employee(int id, string firstName, string lastName)
            : base(id)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
        }

        public string? LastName { get; private set; }

        public string? FirstName { get; private set; }

        public string? Title { get; set; }

        public string? TitleOfCourtesy { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime HireDate { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? HomePhone { get; set; }

        public string? Extension { get; set; }

        public string? Notes { get; set; }

        public int? ReportsTo { get; set; }

        public string? PhotoPath { get; set; }

        private void SetFirstName(string firstName)
        {
            FirstName = Check.NotNullOrWhiteSpace(
                firstName,
                nameof(firstName),
                maxLength: EmployeeConsts.MaxEployeeFirstNameLength);
        }

        private void SetLastName(string lastName)
        {
            LastName = Check.NotNullOrWhiteSpace(
                lastName,
                nameof(lastName),
                maxLength: EmployeeConsts.MaxEployeeLastNameLength);
        }
    }
}
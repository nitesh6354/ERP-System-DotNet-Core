using System;

namespace ERP.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }

        public string EmployeeCode { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateOfJoining { get; set; }
        public decimal Salary { get; set; }

        public int? DepartmentId { get; set; }
    }
}

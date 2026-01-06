using ERP.Application.DTOs.Employee;
using ERP.Application.Interfaces;
using ERP.Domain.Entities;

namespace ERP.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                EmployeeCode = dto.EmployeeCode,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DateOfJoining = dto.DateOfJoining,
                Salary = dto.Salary
            };

            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();

            return employees
                .Where(e => !e.IsDeleted)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmployeeCode = e.EmployeeCode,
                    FullName = e.FirstName + " " + e.LastName,
                    Email = e.Email
                });
        }
    }
}

using ERP.Application.DTOs.Employee;

namespace ERP.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateAsync(CreateEmployeeDto dto);
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
    }
}

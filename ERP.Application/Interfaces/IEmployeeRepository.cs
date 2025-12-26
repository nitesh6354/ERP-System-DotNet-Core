using ERP.Domain.Entities;

namespace ERP.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        Task<List<Employee>> GetAllAsync();
        Task SaveChangesAsync();
    }
}

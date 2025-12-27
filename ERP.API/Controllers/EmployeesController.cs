using ERP.API.Models;
using ERP.Application.DTOs.Employee;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // ===============================
        // POST: api/employee
        // ===============================
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            var employeeId = await _employeeService.CreateAsync(dto);

            var response = new ApiResponse<int>
            {
                Success = true,
                Message = "Employee created successfully",
                Data = employeeId
            };

            return Ok(response);
        }

        // ===============================
        // GET: api/employee
        // ===============================
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllAsync();

            var response = new ApiResponse<IEnumerable<EmployeeDto>>
            {
                Success = true,
                Message = "Employees fetched successfully",
                Data = employees
            };

            return Ok(response);
        }
    }
}

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

        // Constructor Injection
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // ===============================
        // POST: api/employee
        // Create a new employee
        // ===============================
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(
            [FromBody] CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeId = await _employeeService.CreateAsync(dto);

            return Ok(new
            {
                Message = "Employee created successfully",
                EmployeeId = employeeId
            });
        }

        // ===============================
        // GET: api/employee
        // Get all employees
        // ===============================
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }
    }
}

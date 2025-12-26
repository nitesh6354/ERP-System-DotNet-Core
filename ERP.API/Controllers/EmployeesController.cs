using ERP.API.Models;
using ERP.Application.DTOs.Employee;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        // Constructor Injection (Dependency Injection)
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // POST: api/employees
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            var employeeId = await _employeeService.CreateAsync(dto);

            var response = new ApiResponse<int>
            {
                Success = true,
                Message = "Employee created successfully",
                Data = employeeId
            };

            // 201 Created
            return StatusCode(StatusCodes.Status201Created, response);
        }

        // GET: api/employees
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();

            var response = new ApiResponse<IEnumerable<EmployeeDto>>
            {
                Success = true,
                Message = "Employees fetched successfully",
                Data = employees
            };

            return Ok(response); // 200 OK
        }
    }
}

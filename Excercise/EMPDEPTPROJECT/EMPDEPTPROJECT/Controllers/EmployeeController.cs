using EMPDEPTPROJECT.Entities;
using EMPDEPTPROJECT.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPDEPTPROJECT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IRepository<Department> _deptRepo;
        private readonly IRepository<Project> _projectRepo;

        public EmployeeController(IFactory factory)
        {
            _employeeRepo = factory.GetRepository<Employee>();
            _deptRepo = factory.GetRepository<Department>();
            _projectRepo = factory.GetRepository<Project>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees() => Ok(await _employeeRepo.GetAllAsync());

        [HttpGet("departments")]
        public async Task<IActionResult> GetDepartmentsDropdown() => Ok(await _deptRepo.GetAllAsync());

        [HttpGet("projects")]
        public async Task<IActionResult> GetProjectsDropdown() => Ok(await _projectRepo.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            await _employeeRepo.AddAsync(emp);
            await _employeeRepo.SaveAsync();
            return Ok(emp);
        }
    }

}

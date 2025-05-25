using EMPDEPTPROJECT.Entities;
using EMPDEPTPROJECT.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPDEPTPROJECT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _deptRepo;

        public DepartmentController(IFactory factory)
        {
            _deptRepo = factory.GetRepository<Department>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _deptRepo.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dept = await _deptRepo.GetByIdAsync(id);
            if (dept == null)
                return NotFound();
            return Ok(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department dept)
        {
            await _deptRepo.AddAsync(dept);
            await _deptRepo.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = dept.DeptNo }, dept);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Department dept)
        {
            if (id != dept.DeptNo)
                return BadRequest();

            _deptRepo.Update(dept);
            await _deptRepo.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dept = await _deptRepo.GetByIdAsync(id);
            if (dept == null)
                return NotFound();

            _deptRepo.Delete(dept);
            await _deptRepo.SaveAsync();
            return NoContent();
        }
    }
}

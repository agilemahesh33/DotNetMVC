using EMPDEPTPROJECT.Entities;
using EMPDEPTPROJECT.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPDEPTPROJECT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository<Project> _projectRepo;

        public ProjectController(IFactory factory)
        {
            _projectRepo = factory.GetRepository<Project>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectRepo.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            await _projectRepo.AddAsync(project);
            await _projectRepo.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = project.ProjectId }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Project project)
        {
            if (id != project.ProjectId)
                return BadRequest();

            _projectRepo.Update(project);
            await _projectRepo.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            _projectRepo.Delete(project);
            await _projectRepo.SaveAsync();
            return NoContent();
        }
    }
}

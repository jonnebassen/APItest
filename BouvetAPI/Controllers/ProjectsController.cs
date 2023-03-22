using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BouvetAPI.Infrastructure.Contexts;
using BouvetAPI.Models;
using BouvetAPI.Models.DTO;
using BouvetAPI.Services;

namespace BouvetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IScrumBoard _scrumBoard;

        public ProjectsController(IScrumBoard scrumboard)
        {
            _scrumBoard = scrumboard;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _scrumBoard.GetProjectsAsync();
          if (projects == null)
          {
              return NotFound();
          }
            return Ok(projects);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(long id)
        {
            ProjectDTO projectDTO = await _scrumBoard.GetProjectAsync(id);
          if (projectDTO == null)
          {
              return NotFound();
          }

            return Ok(projectDTO);
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(long id, ProjectDTO projectDTO)
        {
            if (id != projectDTO.Id)
            {
                return BadRequest();
            }

            ProjectDTO dbProject = await _scrumBoard.UpdateProjectAsync(id, projectDTO);

            if (dbProject == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProject(ProjectDTO projectDTO)
        {
            var dbProject = await _scrumBoard.AddProjectAsync(projectDTO);

            if (dbProject == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction(nameof(GetProject), new { id = dbProject.Id }, dbProject);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(long id)
        {

            var (status, message) = await _scrumBoard.DeleteProjectAsync(id);

            if (!status)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return Ok($"Deleted project with id: {id}" );
        }


    }
}

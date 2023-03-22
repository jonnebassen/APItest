using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BouvetAPI.Infrastructure.Contexts;
using BouvetAPI.Models;
using BouvetAPI.Services;

namespace BouvetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorktasksController : ControllerBase
    {
        private readonly IScrumBoard _scrumBoard;

        public WorktasksController(IScrumBoard scrumboard)
        {
            _scrumBoard = scrumboard;
        }

        // GET: api/Worktasks
        [HttpGet]
        public async Task<IActionResult> GetWorktasks()
        {
            var worktasks = await _scrumBoard.GetWorktasksAsync();
            if (worktasks == null)
            {
                return NotFound();
            }
            return Ok(worktasks);
        }

        // GET: api/Worktasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorktask(long id)
        {
            Worktask worktask = await _scrumBoard.GetWorktaskAsync(id);
            if (worktask == null)
            {
                return NotFound();
            }

            return Ok(worktask);
        }

        // PUT: api/Worktasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorktask(long id, Worktask worktask)
        {
            if (id != worktask.Id)
            {
                return BadRequest();
            }

            Worktask dbWorktask = await _scrumBoard.UpdateWorktaskAsync(id, worktask);

            if (dbWorktask == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/Worktasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostWorktask(Worktask worktask)
        {
            var dbWorktask = await _scrumBoard.AddWorktaskAsync(worktask);

            if (dbWorktask == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction(nameof(GetWorktask), new { id = worktask.Id }, worktask);
        }

        // DELETE: api/Worktasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorktask(long id)
        {
            var worktask = await _scrumBoard.GetWorktaskAsync(id);

            var (status, message) = await _scrumBoard.DeleteWorktaskAsync(worktask);

            if (!status)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return Ok(worktask);
        }
    }
}

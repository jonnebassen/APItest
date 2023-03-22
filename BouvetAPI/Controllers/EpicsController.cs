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
    public class EpicsController : ControllerBase
    {
        private readonly IScrumBoard _scrumBoard;

        public EpicsController(IScrumBoard scrumboard)
        {
            _scrumBoard = scrumboard;
        }

        // GET: api/Epics
        [HttpGet]
        public async Task<IActionResult> GetEpics()
        {
            var epics = await _scrumBoard.GetEpicsAsync();
            if (epics == null)
            {
                return NotFound();
            }
            return Ok(epics);
        }

        // GET: api/Epics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpic(long id)
        {
            Epic epic = await _scrumBoard.GetEpicAsync(id);
            if (epic == null)
            {
                return NotFound();
            }

            return Ok(epic);
        }

        // PUT: api/Epics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpic(long id, Epic epic)
        {
            if (id != epic.Id)
            {
                return BadRequest();
            }

            Epic dbEpic = await _scrumBoard.UpdateEpicAsync(id, epic);

            if (dbEpic == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/Epics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostEpic(Epic epic)
        {
            var dbEpic = await _scrumBoard.AddEpicAsync(epic);

            if (dbEpic == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction(nameof(GetEpic), new { id = epic.Id }, epic);
        }

        // DELETE: api/Epics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpic(long id)
        {
            var epic = await _scrumBoard.GetEpicAsync(id);

            var (status, message) = await _scrumBoard.DeleteEpicAsync(epic);

            if (!status)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return Ok(epic);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDT.Accessor;
using CDT.Models;

namespace CDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDataController : ControllerBase
    {
        private readonly CDTData _context;

        public ProjectDataController(CDTData context)
        {
            _context = context;
        }

        // GET: api/ProjectData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectData>>> GetProjectData()
        {
            return await _context.ProjectData.ToListAsync();
        }

        // GET: api/ProjectData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectData>> GetProjectData(int id)
        {
            var projectData = await _context.ProjectData.FindAsync(id);

            if (projectData == null)
            {
                return NotFound();
            }

            return projectData;
        }

        // PUT: api/ProjectData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectData(int id, ProjectData projectData)
        {
            if (id != projectData.ID)
            {
                return BadRequest();
            }

            _context.Entry(projectData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectData
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProjectData>> PostProjectData(ProjectData projectData)
        {
            _context.ProjectData.Add(projectData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectData", new { id = projectData.ID }, projectData);
        }

        // DELETE: api/ProjectData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectData>> DeleteProjectData(int id)
        {
            var projectData = await _context.ProjectData.FindAsync(id);
            if (projectData == null)
            {
                return NotFound();
            }

            _context.ProjectData.Remove(projectData);
            await _context.SaveChangesAsync();

            return projectData;
        }

        private bool ProjectDataExists(int id)
        {
            return _context.ProjectData.Any(e => e.ID == id);
        }
    }
}

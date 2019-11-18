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
    public class AppDataController : ControllerBase
    {
        private readonly CDTData _context;

        public AppDataController(CDTData context)
        {
            _context = context;
        }

        // GET: api/AppData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppData>>> GetAppData()
        {
            return await _context.AppData.ToListAsync();
        }

        // GET: api/AppData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppData>> GetAppData(int id)
        {
            var appData = await _context.AppData.FindAsync(id);

            if (appData == null)
            {
                return NotFound();
            }

            return appData;
        }

        // PUT: api/AppData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppData(int id, AppData appData)
        {
            if (id != appData.ID)
            {
                return BadRequest();
            }

            _context.Entry(appData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppDataExists(id))
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

        // POST: api/AppData
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AppData>> PostAppData(AppData appData)
        {
            _context.AppData.Add(appData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppData", new { id = appData.ID }, appData);
        }

        // DELETE: api/AppData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppData>> DeleteAppData(int id)
        {
            var appData = await _context.AppData.FindAsync(id);
            if (appData == null)
            {
                return NotFound();
            }

            _context.AppData.Remove(appData);
            await _context.SaveChangesAsync();

            return appData;
        }

        private bool AppDataExists(int id)
        {
            return _context.AppData.Any(e => e.ID == id);
        }
    }
}

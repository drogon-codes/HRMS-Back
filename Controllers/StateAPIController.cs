using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSCoreWebApp.Models;

namespace HRMSCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public StateAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/StateAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateMaster>>> GetStateMaster()
        {
            return await _context.StateMaster.ToListAsync();
        }

        // GET: api/StateAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateMaster>> GetStateMaster(int id)
        {
            var stateMaster = await _context.StateMaster.FindAsync(id);

            if (stateMaster == null)
            {
                return NotFound();
            }

            return stateMaster;
        }

        // PUT: api/StateAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStateMaster(int id, StateMaster stateMaster)
        {
            if (id != stateMaster.StateId)
            {
                return BadRequest();
            }

            _context.Entry(stateMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateMasterExists(id))
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

        // POST: api/StateAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StateMaster>> PostStateMaster(StateMaster stateMaster)
        {
            _context.StateMaster.Add(stateMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStateMaster", new { id = stateMaster.StateId }, stateMaster);
        }

        // DELETE: api/StateAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StateMaster>> DeleteStateMaster(int id)
        {
            var stateMaster = await _context.StateMaster.FindAsync(id);
            if (stateMaster == null)
            {
                return NotFound();
            }

            _context.StateMaster.Remove(stateMaster);
            await _context.SaveChangesAsync();

            return stateMaster;
        }

        private bool StateMasterExists(int id)
        {
            return _context.StateMaster.Any(e => e.StateId == id);
        }
    }
}

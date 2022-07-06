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
    public class AllowanceGradeAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public AllowanceGradeAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/AllowanceGradeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllowanceGrade>>> GetAllowanceGrade()
        {
            return await _context.AllowanceGrade.ToListAsync();
        }

        // GET: api/AllowanceGradeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllowanceGrade>> GetAllowanceGrade(int id)
        {
            var allowanceGrade = await _context.AllowanceGrade.FindAsync(id);

            if (allowanceGrade == null)
            {
                return NotFound();
            }

            return allowanceGrade;
        }

        // GET: api/AllowanceGradeAPI/5
        [HttpGet]
        [Route("{AllowanceDetail}/{GradeId}")]
        public async Task<ActionResult<IEnumerable<AllowanceDetail>>> GetAllowanceByGradeId(int GradeId)
        {
            var allowanceGrade = await _context.AllowanceGrade.FindAsync(GradeId);

            List<AllowanceDetail> allowances = null;
            allowances = await (from ag in _context.AllowanceGrade
                                join am in _context.AllowanceMaster
                                on ag.AllowanceId equals am.AllowanceId
                                where ag.GradeId == GradeId
                                select new AllowanceDetail 
                                {
                                    AllowanceId = ag.AllowanceId,
                                    AllowanceName = am.AllowanceName,
                                    AllowanceRate = ag.AllowanceRate,
                                    AllowanceGradeId = ag.AllowanceGradeId,
                                    GradeId = ag.GradeId,
                                    IsTaxable = am.IsTaxable
                                }
                                ).ToListAsync<AllowanceDetail>();

            if (allowances == null)
            {
                return NotFound();
            }

            return allowances;
        }

        // PUT: api/AllowanceGradeAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowanceGrade(int id, AllowanceGrade allowanceGrade)
        {
            if (id != allowanceGrade.AllowanceGradeId)
            {
                return BadRequest();
            }

            _context.Entry(allowanceGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowanceGradeExists(id))
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

        // POST: api/AllowanceGradeAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AllowanceGrade>> PostAllowanceGrade(AllowanceGrade allowanceGrade)
        {
            _context.AllowanceGrade.Add(allowanceGrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllowanceGrade", new { id = allowanceGrade.AllowanceGradeId }, allowanceGrade);
        }

        // DELETE: api/AllowanceGradeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AllowanceGrade>> DeleteAllowanceGrade(int id)
        {
            var allowanceGrade = await _context.AllowanceGrade.FindAsync(id);
            if (allowanceGrade == null)
            {
                return NotFound();
            }

            _context.AllowanceGrade.Remove(allowanceGrade);
            await _context.SaveChangesAsync();

            return allowanceGrade;
        }

        private bool AllowanceGradeExists(int id)
        {
            return _context.AllowanceGrade.Any(e => e.AllowanceGradeId == id);
        }
    }
}

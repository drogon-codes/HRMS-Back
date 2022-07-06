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
    public class AttendanceAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public AttendanceAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/AttendanceAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceMaster>>> GetAttendanceMaster()
        {
            return await _context.AttendanceMaster.ToListAsync();
        }

        // GET: api/AttendanceAPI/AttendanceByEmployee/EmployeeID
        [HttpGet]
        [Route("{AttendanceByEmployee}/{id}")]
        public async Task<ActionResult<IEnumerable<AttendanceByEmployee>>> GetAttendanceByEmployee(int id)
        {
            List<AttendanceByEmployee> attendance = null;
            attendance = await (from am in _context.AttendanceMaster
                                where am.EmployeeId == id
                                select new AttendanceByEmployee
                                {
                                   AttendanceId=am.AttendanceId,
                                   EmployeeId=am.EmployeeId,
                                   TimeOfArrival=am.TimeOfArrival,
                                   TimeOfLeave=am.TimeOfLeave,
                                   OverTimeHours=am.OverTimeHours,
                                   AttendanceDate=am.AttendanceDate,
                                   TotalHours = am.TimeOfLeave - am.TimeOfArrival
                                }).ToListAsync<AttendanceByEmployee>();
             return attendance;
        }

        // GET: api/AttendanceAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceMaster>> GetAttendanceMaster(int id)
        {
            var attendanceMaster = await _context.AttendanceMaster.FindAsync(id);

            if (attendanceMaster == null)
            {
                return NotFound();
            }

            return attendanceMaster;
        }

        // PUT: api/AttendanceAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceMaster(int id, AttendanceMaster attendanceMaster)
        {
            if (id != attendanceMaster.AttendanceId)
            {
                return BadRequest();
            }

            _context.Entry(attendanceMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceMasterExists(id))
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

        // POST: api/AttendanceAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AttendanceMaster>> PostAttendanceMaster(AttendanceMaster attendanceMaster)
        {
            _context.AttendanceMaster.Add(attendanceMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendanceMaster", new { id = attendanceMaster.AttendanceId }, attendanceMaster);
        }

        // DELETE: api/AttendanceAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AttendanceMaster>> DeleteAttendanceMaster(int id)
        {
            var attendanceMaster = await _context.AttendanceMaster.FindAsync(id);
            if (attendanceMaster == null)
            {
                return NotFound();
            }

            _context.AttendanceMaster.Remove(attendanceMaster);
            await _context.SaveChangesAsync();

            return attendanceMaster;
        }

        private bool AttendanceMasterExists(int id)
        {
            return _context.AttendanceMaster.Any(e => e.AttendanceId == id);
        }
    }
}

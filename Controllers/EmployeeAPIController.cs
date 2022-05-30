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
    public class EmployeeAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public EmployeeAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeMaster>>> GetEmployeeMaster()
        {
            return await _context.EmployeeMaster.ToListAsync();
        }

        // GET: api/EmployeeAPI
        [HttpPost]
        [Route("Login")]
        public ActionResult<EmployeeMaster> Login(EmployeeMaster employee)
        {
            var _admin = _context.EmployeeMaster.Where(e => e.EmployeeEmail.Equals(employee.EmployeeEmail));
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Password.Equals(employee.Password)).Any())
                {
                    return CreatedAtAction("GetEmployeeMaster", new { id = employee.EmployeeId }, _admin);
                    //return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return NotFound();
                    //return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return NotFound();
                //return Json(new { status = false, message = "Invalid Email!" });
            }
            //return await _context.EmployeeMaster.ToListAsync();
        }

        // GET: api/EmployeeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeMaster>> GetEmployeeMaster(int id)
        {
            var employeeMaster = await _context.EmployeeMaster.FindAsync(id);

            if (employeeMaster == null)
            {
                return NotFound();
            }

            return employeeMaster;
        }

        // PUT: api/EmployeeAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeMaster(int id, EmployeeMaster employeeMaster)
        {
            if (id != employeeMaster.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeMasterExists(id))
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

        // POST: api/EmployeeAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeMaster>> PostEmployeeMaster(EmployeeMaster employeeMaster)
        {
            _context.EmployeeMaster.Add(employeeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeMaster", new { id = employeeMaster.EmployeeId }, employeeMaster);
        }

        // DELETE: api/EmployeeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeMaster>> DeleteEmployeeMaster(int id)
        {
            var employeeMaster = await _context.EmployeeMaster.FindAsync(id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            _context.EmployeeMaster.Remove(employeeMaster);
            await _context.SaveChangesAsync();

            return employeeMaster;
        }

        private bool EmployeeMasterExists(int id)
        {
            return _context.EmployeeMaster.Any(e => e.EmployeeId == id);
        }
    }
}

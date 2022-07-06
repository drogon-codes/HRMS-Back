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
            //List<EmployeeDetail> emps = null;
            //emps = await (from e in _context.EmployeeMaster
            //              join c in _context.CityMaster
            //              on e.CityId equals c.CityId
            //              join eg in _context.EmployeeGrade
            //              on e.EmployeeId equals eg.EmployeeId
            //              join gm in _context.GradeMaster
            //              on eg.GradeId equals gm.GradeId
            //              join desg in _context.DesignationGrade
            //              on gm.GradeId equals desg.GradeId
            //              join desm in _context.DesignationMaster
            //              on desg.DesignationId equals desm.DesignationId
            //              join depm in _context.DepartmentMaster
            //              on desm.DepartmentId equals depm.DepartmentId
            //              select new EmployeeDetail
            //              {
            //                    EmployeeId = e.EmployeeId,
            //                    EmployeeFname = e.EmployeeFname,
            //                    EmployeeMname = e.EmployeeMname,
            //                    EmployeeLname = e.EmployeeLname,
            //                    EmployeeEmail = e.EmployeeEmail,
            //                    Password = e.Password,
            //                    EmployeeContact = e.EmployeeContact,
            //                    EmployeeDoj = e.EmployeeDoj,
            //                    EmployeeAddress = e.EmployeeAddress,
            //                    CityId = e.CityId,
            //                    CityName = c.CityName,
            //                    PanNo = e.PanNo,
            //                    PanCopy = e.PanCopy,
            //                    Qualifications = e.Qualifications,
            //                    Experiance = e.Experiance,
            //                    BankAcNo = e.BankAcNo,
            //                    BankIfsccode = e.BankIfsccode,
            //                    BankHolderName = e.BankHolderName,
            //                    GradeId = eg.GradeId,
            //                    GradeName = gm.GradeName,
            //                    Designation = desm.DesignationName,
            //                    Department = depm.DepartmentName
            //              }).ToListAsync<EmployeeDetail>();
            return await _context.EmployeeMaster.ToListAsync();
            //return emps;
        }

        [HttpGet]
        [Route("AllEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetAllEmployees()
        {
            List<EmployeeDetail> emps = null;
            emps = await (from e in _context.EmployeeMaster
                          join c in _context.CityMaster
                          on e.CityId equals c.CityId
                          join eg in _context.EmployeeGrade
                          on e.EmployeeId equals eg.EmployeeId
                          join gm in _context.GradeMaster
                          on eg.GradeId equals gm.GradeId
                          join desg in _context.DesignationGrade
                          on gm.GradeId equals desg.GradeId
                          join desm in _context.DesignationMaster
                          on desg.DesignationId equals desm.DesignationId
                          join depm in _context.DepartmentMaster
                          on desm.DepartmentId equals depm.DepartmentId
                          select new EmployeeDetail
                          {
                              EmployeeId = e.EmployeeId,
                              EmployeeFname = e.EmployeeFname,
                              EmployeeMname = e.EmployeeMname,
                              EmployeeLname = e.EmployeeLname,
                              EmployeeEmail = e.EmployeeEmail,
                              Password = e.Password,
                              EmployeeContact = e.EmployeeContact,
                              EmployeeDoj = e.EmployeeDoj,
                              EmployeeAddress = e.EmployeeAddress,
                              CityId = e.CityId,
                              CityName = c.CityName,
                              PanNo = e.PanNo,
                              PanCopy = e.PanCopy,
                              Qualifications = e.Qualifications,
                              Experiance = e.Experiance,
                              BankAcNo = e.BankAcNo,
                              BankIfsccode = e.BankIfsccode,
                              BankHolderName = e.BankHolderName,
                              GradeId = eg.GradeId,
                              GradeName = gm.GradeName,
                              Designation = desm.DesignationName,
                              Department = depm.DepartmentName,
                              EmployeeGradeId = eg.EmployeeGradeId
                          }).ToListAsync<EmployeeDetail>();
            //return await _context.EmployeeMaster.ToListAsync();
            return emps;
        }


        [HttpGet]
        [Route("UngradeEmployee")]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetUngradeEmployees()
        {
            List<EmployeeDetail> emps = null;
            emps = await (from e in _context.EmployeeMaster
                          join eg in _context.EmployeeGrade
                          on e.EmployeeId equals eg.EmployeeId
                          into EmployeeGrade
                          from emg in EmployeeGrade.DefaultIfEmpty()
                          where e.EmployeeId != emg.EmployeeId
                          //where e.EmployeeId.Equals(eg.EmployeeId)
                          select new EmployeeDetail
                          {
                              EmployeeId = e.EmployeeId,
                              EmployeeFname = e.EmployeeFname,
                              EmployeeMname = e.EmployeeMname,
                              EmployeeLname = e.EmployeeLname,
                              EmployeeEmail = e.EmployeeEmail,
                              Password = e.Password,
                              EmployeeContact = e.EmployeeContact,
                              EmployeeDoj = e.EmployeeDoj,
                              EmployeeAddress = e.EmployeeAddress,
                              CityId = e.CityId,
                              CityName = "",
                              PanNo = e.PanNo,
                              PanCopy = e.PanCopy,
                              Qualifications = e.Qualifications,
                              Experiance = e.Experiance,
                              BankAcNo = e.BankAcNo,
                              BankIfsccode = e.BankIfsccode,
                              BankHolderName = e.BankHolderName,
                              GradeId = emg.GradeId,
                              GradeName = "",
                              Designation = "",
                              Department = "",
                              EmployeeGradeId = emg.EmployeeGradeId
                          }).ToListAsync<EmployeeDetail>();
            //return await _context.EmployeeMaster.ToListAsync();
            return emps;
        }

        [HttpGet]
        [Route("{GetEmployee}/{empId}")]
        
        public async Task<ActionResult<EmployeeSalaryReport>> GetEmployeeForSalary(int empId)
        {
            var emps = await (from e in _context.EmployeeMaster
                          join c in _context.CityMaster
                          on e.CityId equals c.CityId
                          join eg in _context.EmployeeGrade
                          on e.EmployeeId equals eg.EmployeeId
                          join gm in _context.GradeMaster
                          on eg.GradeId equals gm.GradeId
                          join ag in _context.AllowanceGrade
                          on eg.GradeId equals ag.GradeId
                          join am in _context.AllowanceMaster
                          on ag.AllowanceId equals am.AllowanceId
                          join dg in _context.DeductionGrade
                          on eg.GradeId equals dg.GradeId
                          join dm in _context.DeductionMaster
                          on dg.DeductionId equals dm.DeductionId
                          join desg in _context.DesignationGrade
                          on gm.GradeId equals desg.GradeId
                          join desm in _context.DesignationMaster
                          on desg.DesignationId equals desm.DesignationId
                          join depm in _context.DepartmentMaster
                          on desm.DepartmentId equals depm.DepartmentId
                          where e.EmployeeId==empId
                          select new EmployeeSalaryReport
                          {
                              EmployeeId = e.EmployeeId,
                              EmployeeFname = e.EmployeeFname,
                              EmployeeMname = e.EmployeeMname,
                              EmployeeLname = e.EmployeeLname,
                              EmployeeEmail = e.EmployeeEmail,
                              EmployeeDoj = e.EmployeeDoj,
                              PanNo = e.PanNo,
                              BankAcNo = e.BankAcNo,
                              BankIfsccode = e.BankIfsccode,
                              BankHolderName = e.BankHolderName,
                              GradeId = eg.GradeId,
                              GradeName = gm.GradeName,
                              ModeOfSalary = gm.ModeOfSalary,
                              DailySalary = gm.DailySalary,
                              WagePerHour = gm.WagePerHour,
                              AllowanceId = ag.AllowanceId,
                              AllowanceName = am.AllowanceName,
                              AllowanceRate = ag.AllowanceRate,
                              DeductionId = dg.DeductionId,
                              DeductionName = dm.DeductionName,
                              DeductionRate = dg.DeductionRate,
                              Designation = desm.DesignationName,
                              Department = depm.DepartmentName,
                              EmployeeGradeId = eg.EmployeeGradeId
                          }).FirstOrDefaultAsync< EmployeeSalaryReport>();
            //return await _context.EmployeeMaster.ToListAsync();
            return emps;
        }

        // GET: api/EmployeeAPI
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<EmployeeMaster>> Login(EmployeeMaster employee)
        {
            //var _admin = _context.EmployeeMaster.Where(e => e.EmployeeEmail.Equals(employee.EmployeeEmail));
            EmployeeMaster emp = new EmployeeMaster();
            emp = await _context.EmployeeMaster.Where(x => x.EmployeeEmail.Equals(employee.EmployeeEmail) && x.Password.Equals(employee.Password)).FirstOrDefaultAsync();
            return emp;
            //EmployeeMaster emp = null;
            //emp = await (from e in _context.EmployeeMaster
            //            where e.EmployeeEmail == employee.EmployeeEmail
            //            && e.Password == employee.Password
            //            select new EmployeeMaster
            //            {
            //                Emplo
            //            }).FirstOrDefaultAsync<EmployeeMaster>;
            //if (_admin.Any())
            //{
            //    if (_admin.Where(s => s.Password.Equals(employee.Password)).Any())
            //    {
            //        return CreatedAtAction("GetEmployeeMaster", new { id = employee.EmployeeId }, _admin);
            //        //return Json(new { status = true, message = "Login Successfull!" });
            //    }
            //    else
            //    {
            //        return NotFound();
            //        //return Json(new { status = false, message = "Invalid Password!" });
            //    }
            //}
            //else
            //{
            //    return NotFound();
            //    //return Json(new { status = false, message = "Invalid Email!" });
            //}
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

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
    public class GradeAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public GradeAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/GradeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeMaster>>> GetGradeMaster()
        {
            return await _context.GradeMaster.ToListAsync();
        }

        // GET: api/GradeAPI
        [HttpGet]
        [Route("HrGrade")]
        public async Task<ActionResult<IEnumerable<HrGrade>>> GetHrGrade()
        {
            List<HrGrade> grades = null;
            grades = await (from g in _context.GradeMaster
                            select new HrGrade
                            {
                                GradeId = g.GradeId,
                                GradeName = g.GradeName,
                                ModeOfSalary = g.ModeOfSalary,
                                DailySalary = g.DailySalary,
                                WagePerHour = g.WagePerHour,
                            }
                ).ToListAsync<HrGrade>();
            return grades;
        }

        // GET: api/GradeAPI
        [HttpGet]
        [Route("{GradeDetail}/{GradeId}")]
        public async Task<ActionResult<HrGrade>> GetHrGradeDetail(int GradeId)
        {
            var grades = await (from g in _context.GradeMaster
                            join desg in _context.DesignationGrade
                            on g.GradeId equals desg.GradeId
                            join desm in _context.DesignationMaster
                            on desg.DesignationId equals desm.DesignationId
                            join dept in _context.DepartmentMaster
                            on desm.DepartmentId equals dept.DepartmentId
                            where g.GradeId == GradeId
                            select new HrGrade
                            {
                                GradeId = g.GradeId,
                                GradeName = g.GradeName,
                                DepartmentName = dept.DepartmentName,
                                DesignationName = desm.DesignationName,
                                //Allowance = am.AllowanceName,
                                //AllowanceRate = ag.AllowanceRate,
                                //Deduction = dm.DeductionName,
                                //DeductionRate = dg.DeductionRate,
                                ModeOfSalary = g.ModeOfSalary,
                                DailySalary = g.DailySalary,
                                WagePerHour = g.WagePerHour,
                                DesignationGradeId = desg.DesignationGradeId,
                                //AllowanceGradeId = ag.AllowanceGradeId,
                                //DeductionGradId = dg.DeductionGradeId

                            }
                ).FirstOrDefaultAsync<HrGrade>();
            return grades;
        }

        // DELETE: api/GradeAPI/5
        [HttpDelete]
        [Route("{HrGrade}/{desigId}/{allId}/{dedId}")]
        public async Task<ActionResult<bool>> DeleteHrGradeMaster(int gradeId, int desigId, int allId, int dedId)
        {
            var designationGrade = await _context.DesignationGrade.FindAsync(desigId);
            var allowanceGrade = await _context.AllowanceGrade.FindAsync(allId);
            var deductionGrade = await _context.DeductionGrade.FindAsync(dedId);
            if (designationGrade == null || allowanceGrade == null || deductionGrade == null)
            {
                return NotFound();
            }

            _context.DesignationGrade.Remove(designationGrade);
            _context.AllowanceGrade.Remove(allowanceGrade);
            _context.DeductionGrade.Remove(deductionGrade);
            await _context.SaveChangesAsync();

            return true;
        }

        // GET: api/GradeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeMaster>> GetGradeMaster(int id)
        {
            var gradeMaster = await _context.GradeMaster.FindAsync(id);

            if (gradeMaster == null)
            {
                return NotFound();
            }

            return gradeMaster;
        }

        // GET: api/GradeAPI/HrGrade/1/2/3/4
        [HttpGet]
        [Route("{HrGrade}/{gradeId}/{desigId}/{allId}/{dedId}")]
        public async Task<ActionResult<IEnumerable<HrGrade>>> GetSingleHrGrade(int gradeId, int desigId, int allId, int dedId)
        {
            List<HrGrade> grades = null;
            grades = await (from g in _context.GradeMaster
                            join ag in _context.AllowanceGrade
                            on g.GradeId equals ag.GradeId
                            join am in _context.AllowanceMaster
                            on ag.AllowanceId equals am.AllowanceId
                            join dg in _context.DeductionGrade
                            on g.GradeId equals dg.GradeId
                            join dm in _context.DeductionMaster
                            on dg.DeductionId equals dm.DeductionId
                            join desg in _context.DesignationGrade
                            on g.GradeId equals desg.GradeId
                            join desm in _context.DesignationMaster
                            on desg.DesignationId equals desm.DesignationId
                            join dept in _context.DepartmentMaster
                            on desm.DepartmentId equals dept.DepartmentId

                            where desg.GradeId == gradeId && desg.DesignationGradeId == desigId &&
                            ag.GradeId == gradeId && ag.AllowanceGradeId == allId &&
                            dg.GradeId == gradeId && dg.DeductionGradeId == dedId

                            select new HrGrade
                            {
                                GradeId = g.GradeId,
                                GradeName = g.GradeName,
                                DepartmentName = dept.DepartmentName,
                                DesignationName = desm.DesignationName,
                                Allowance = am.AllowanceName,
                                AllowanceRate = ag.AllowanceRate,
                                Deduction = dm.DeductionName,
                                DeductionRate = dg.DeductionRate,
                                ModeOfSalary = g.ModeOfSalary,
                                DailySalary = g.DailySalary,
                                WagePerHour = g.WagePerHour,
                                DesignationGradeId = desg.DesignationGradeId,
                                AllowanceGradeId = ag.AllowanceGradeId,
                                DeductionGradId = dg.DeductionGradeId

                            }
                ).ToListAsync<HrGrade>();
            return grades;
        }

            // PUT: api/GradeAPI/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
        public async Task<IActionResult> PutGradeMaster(int id, GradeMaster gradeMaster)
        {
            if (id != gradeMaster.GradeId)
            {
                return BadRequest();
            }

            _context.Entry(gradeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeMasterExists(id))
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

        // POST: api/GradeAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GradeMaster>> PostGradeMaster(GradeMaster gradeMaster)
        {
            _context.GradeMaster.Add(gradeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradeMaster", new { id = gradeMaster.GradeId }, gradeMaster);
        }

        // DELETE: api/GradeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GradeMaster>> DeleteGradeMaster(int id)
        {
            var gradeMaster = await _context.GradeMaster.FindAsync(id);
            if (gradeMaster == null)
            {
                return NotFound();
            }

            _context.GradeMaster.Remove(gradeMaster);
            await _context.SaveChangesAsync();

            return gradeMaster;
        }

        private bool GradeMasterExists(int id)
        {
            return _context.GradeMaster.Any(e => e.GradeId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_LMSapp1.Models;

namespace Project_LMSapp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveApplicationsController : ControllerBase
    {
        private readonly LMSDbContext _context;

        public LeaveApplicationsController(LMSDbContext context)
        {
            _context = context;
        }

        // GET: api/LeaveApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveApplication>>> GetApplyLeave()
        {
            return await _context.ApplyLeave.ToListAsync();
        }
        
        [Route("Leavedetailsbyemployee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveApplication>>> GetLeaveDetails(string eid)
        {
            var result = await _context.ApplyLeave.Where(e => e.EmployeeId == eid).ToListAsync();



            if (result == null)
            {
                return NotFound();
            }



            return result;
        }
        // GET: api/LeaveApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveApplication>> GetLeaveApplication(int id)
        {
            var leaveApplication = await _context.ApplyLeave.FindAsync(id);

            if (leaveApplication == null)
            {
                return NotFound();
            }

            return leaveApplication;
        }

        // PUT: api/LeaveApplications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveApplication(int id, LeaveApplication leaveApplication)
        {
            if (id != leaveApplication.LeaveApplicationId)
            {
                return BadRequest();
            }

            _context.Entry(leaveApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveApplicationExists(id))
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

        // POST: api/LeaveApplications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LeaveApplication>> PostLeaveApplication(LeaveApplication leaveApplication)
        {
            _context.ApplyLeave.Add(leaveApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveApplication", new { id = leaveApplication.LeaveApplicationId }, leaveApplication);
        }

        // DELETE: api/LeaveApplications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveApplication>> DeleteLeaveApplication(int id)
        {
            var leaveApplication = await _context.ApplyLeave.FindAsync(id);
            if (leaveApplication == null)
            {
                return NotFound();
            }

            _context.ApplyLeave.Remove(leaveApplication);
            await _context.SaveChangesAsync();

            return leaveApplication;
        }

        private bool LeaveApplicationExists(int id)
        {
            return _context.ApplyLeave.Any(e => e.LeaveApplicationId == id);
        }
        [Route("overlappingDates")]
        [HttpGet]
        public string OverlapDates(string startDate, string endDate)
        {



            var leave = _context.ApplyLeave.Where(l => l.StartDate.Equals(DateTime.Parse(startDate)) && l.EndDate.Equals(DateTime.Parse(endDate)));
            if (leave.Count() == 0)
            {
                return "Success";
            }
            else
            {
                return"Invalid";
            }
        }
    }
    
      
}

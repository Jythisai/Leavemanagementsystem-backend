using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_LMSapp1.Models;

namespace Project_LMSapp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPagesController : ControllerBase
    {
        private readonly LMSDbContext _context;

        public LoginPagesController(LMSDbContext context)
        {
            _context = context;
        }

        // GET: api/LoginPages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginPage>>> GetLoginPage()
        {
            return await _context.LoginPage.ToListAsync();
        }

        // GET: api/LoginPages/5
        [HttpGet("{id}")]

        public async Task<ActionResult<LoginPage>> GetLoginPage(int id)
        {
            var loginPage = await _context.LoginPage.FindAsync(id);

            if (loginPage == null)
            {
                return NotFound();
            }

            return loginPage;
        }

        // PUT: api/LoginPages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginPage(int id, LoginPage loginPage)
        {
            if (id != loginPage.UserId)
            {
                return BadRequest();
            }

            _context.Entry(loginPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginPageExists(id))
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

        // POST: api/LoginPages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<LoginPage>> PostLoginPage(LoginPage loginPage)
        //{
        //    _context.LoginPage.Add(loginPage);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetLoginPage", new { id = loginPage.UserId }, loginPage);
        //}
        [HttpPost]
        public string PostLogin(LoginPage login1)
        {
            var empid = int.Parse(login1.EmployeeId);
            var log = _context.Employees.Find(empid);


            if (log == null)
            {
                return "Invalid credentials";
            }
            else if(log.Password!=login1.Password)
            {
                return "Invalid credentials";
            }
            else

            return "Login Success";
        }
        // DELETE: api/LoginPages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginPage>> DeleteLoginPage(int id)
        {
            var loginPage = await _context.LoginPage.FindAsync(id);
            if (loginPage == null)
            {
                return NotFound();
            }

            _context.LoginPage.Remove(loginPage);
            await _context.SaveChangesAsync();

            return loginPage;
        }

        private bool LoginPageExists(int id)
        {
            return _context.LoginPage.Any(e => e.UserId == id);
        }
    }
}

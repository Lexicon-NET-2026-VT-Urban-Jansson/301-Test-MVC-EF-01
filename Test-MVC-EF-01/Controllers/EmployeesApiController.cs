using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_MVC_EF_01.Data;

namespace Test_MVC_EF_01.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesApiController(ApplicationDbContext context) : ControllerBase
    {
        // --------------------------------------------------------------------
        // *** API - GetEmployees() ***
        // --------------------------------------------------------------------
        [HttpGet("")]
        public async Task<IActionResult> GetEmployees()
        {
            var results = await context.Employees
                //.Include(x => x.Office)               // Example of relational inclusion
                .OrderByDescending(e => e.FirstName)
                .ToListAsync();

            if (results.Count == 0) return NotFound();
            return Ok(results);
        }

        // --------------------------------------------------------------------
        // *** API - GetEmployee(int id) ***
        // --------------------------------------------------------------------
        [HttpGet("{id:int}", Name = "GetOneEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result = await context.Employees
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        // --------------------------------------------------------------------
        // *** API - DeleteEmployee(int id) ***
        // --------------------------------------------------------------------
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var oldEmployee = await context.Employees
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (oldEmployee is null) return NotFound();

            context.Employees.Remove(oldEmployee);
            if (await context.SaveChangesAsync() > 0) return Ok();

            return BadRequest();
        }
    }
}

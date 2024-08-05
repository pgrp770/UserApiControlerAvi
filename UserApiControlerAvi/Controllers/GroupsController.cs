using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApiControlerAvi.Data;
using UserApiControlerAvi.DTOs;
using UserApiControlerAvi.Models;

namespace UserApiControlerAvi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly UserApiControlerAviContext _context;

        public GroupsController(UserApiControlerAviContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group @group)
        {
            if (id != @group.Id)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(AddGrops newGroup)
        {
            Group group = new Group() { Name = newGroup.Name };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = group.Id }, group);
        }

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("addUser/{id}")]
        public async Task<ActionResult<Group>> AddsuserInGroup(int id, int userId)
        {
            
            var groupp = await _context.Groups.FindAsync(id);
            var newUser = await _context.Users.FindAsync(userId);
            newUser.Groups.Add(groupp);
            groupp.Users.Add(newUser);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}

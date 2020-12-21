using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheEnd.Data;
using TheEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIUsersController : ControllerBase
    {

        private readonly ApplicationContext db;

        public APIUsersController(ApplicationContext db)
        {
            this.db = db;
        }
        // GET: api/<APIUsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> Get()
        {
            return await db.Curses.ToListAsync();
        }

        // GET api/<APIUsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            Course user = await db.Curses.FirstOrDefaultAsync(x => x.id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/<APIUsersController>
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Course>> Post(Course user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            db.Curses.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/<APIUsersController>/5
        [HttpPut]
        public async Task<ActionResult<Course>> Put(Course user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Curses.Any(x => x.id == user.id))
            {
                return NotFound();
            }

            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/<APIUsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> Delete(int id)
        {
            Course user = db.Curses.FirstOrDefault(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Curses.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}

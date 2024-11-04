using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using System.Text;
using System.Security.Cryptography;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IsucorpdbContext _context;

        public UsersController(IsucorpdbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'IsucorpdbContext.Users'  is null.");
          }
            //user.PasswordHash = HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Users/login
        //[HttpPost("login")]
        //public async Task<ActionResult<User>> Login(User loginUser)
        //{
        //    if (_context.Users == null)
        //    {
        //        return Problem("Entity set 'IsucorpdbContext.Users' is null.");
        //    }

        //    var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginUser.Username);

        //    if (user == null)
        //    {
        //        return Unauthorized("Invalid username or password.");
        //    }

        //    // Verify password
        //    bool isPasswordValid = VerifyPassword(loginUser.PasswordHash, user.PasswordHash);

        //    if (!isPasswordValid)
        //    {
        //        return Unauthorized("Invalid username or password.");
        //    }

        //    return Ok(user); //Or return a JWT Token or anyother information what do you wish 
        //    // O devuelve un token JWT o cualquier otra información que desees
        //}

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //private string HashPassword(string password)
        //{
        //    using (var sha256 = SHA256.Create())
        //    {
        //        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        StringBuilder builder = new StringBuilder();
        //        foreach (byte b in bytes)
        //        {
        //            builder.Append(b.ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}

        //public bool VerifyPassword(string enteredPassword, string storedHash)
        //{
        //    string hashOfEnteredPassword = HashPassword(enteredPassword);
        //    return hashOfEnteredPassword == storedHash;
        //}

       


    }
}

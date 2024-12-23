using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psychoApp.Data;
using psychoApp.Models;
using psychoApp.Services;

namespace psychoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public UsersController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
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
                return BadRequest(new {message = "User ID does not match."});
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
                    return NotFound(new {message = "User not found."});
                }
                else
                {
                    throw;
                }
            }

            return Ok(new {Success=true,message = "User updated successfully.",updatedUser = user});
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        //POST: api/Users/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == user.Username || u.Email == user.Email);


            if (existingUser != null)
            {

                return Ok(new
                {
                    Success = false,
                    Message = "این نام کاربری یا ایمیل قبلا ثبت نام کرده است.",
                    Date = (object)null
                });

            }

            user.CreatedDate = DateTime.UtcNow;
            user.LastLogin = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            string token = _tokenService.GenerateToken(user.Username);
            string refreshToken = Guid.NewGuid().ToString();

            return Ok(new
            {
                Success = true,
                Message = $"{user.FirstName} عزیز، ثبت‌نام شما با موفقیت انجام شد.",
                Date = new
                {
                    Token = token,
                    RefreshToken = refreshToken
                }
            });

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

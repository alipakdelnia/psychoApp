    using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psychoApp.Data;
using psychoApp.Interfaces;
using psychoApp.Models;
using psychoApp.Services;

namespace psychoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase, IUsersController
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public UsersController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest(new { message = "User ID does not match." });
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
                    return NotFound(new { message = "User not found." });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { Success = true, message = "User updated successfully.", updatedUser = user });
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Success = false, message = "User not found." });
            }

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return Ok(new { Success = true, message = "User deleted successfully (soft deleted)." });
        }

        [HttpGet("{id}/notes")]
        public async Task<ActionResult<IEnumerable<Note>>> GetUserNotes(int id)
        {
            var user = await _context.Users.Include(u => u.Notes).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new { Success = false, message = "user not found/" });
            }

            return Ok(new { Success = true, Notes = user.Notes });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

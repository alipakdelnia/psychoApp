using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psychoApp.Data;
using psychoApp.Models;
using psychoApp.Services;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly AppDbContext _context;

    public AuthController(TokenService tokenService, AppDbContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("login")]
    [AllowAnonymous] // این action برای همه قابل دسترسی است
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        // پیدا کردن کاربر در دیتابیس
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == loginRequest.Username);

        // بررسی وجود کاربر و تطابق رمز عبور
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
        {
            return Unauthorized(new { Success = false, Message = "نام کاربری یا رمز عبور اشتباه است." });
        }

        // ایجاد توکن JWT
        string token = _tokenService.GenerateToken(user.Username);

        return Ok(new
        {
            Success = true,
            Message = "لاگین موفقیت‌آمیز بود.",
            Token = token
        });
    }

    [HttpPost("register")]
    [AllowAnonymous] // این action برای همه قابل دسترسی است
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        // بررسی وجود کاربر با نام کاربری یا ایمیل مشابه
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == registerRequest.Username || u.Email == registerRequest.Email);

        if (existingUser != null)
        {
            return BadRequest(new
            {
                Success = false,
                Message = "این نام کاربری یا ایمیل قبلاً ثبت‌نام کرده است."
            });
        }

        // ایجاد کاربر جدید
        var user = new User
        {
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Username = registerRequest.Username,
            Email = registerRequest.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password), // هش کردن رمز عبور
            CreatedDate = DateTime.UtcNow,
            LastLogin = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // ایجاد توکن JWT
        string token = _tokenService.GenerateToken(user.Username);

        return Ok(new
        {
            Success = true,
            Message = $"{user.FirstName} عزیز، ثبت‌نام شما با موفقیت انجام شد.",
            Token = token
        });
    }
}
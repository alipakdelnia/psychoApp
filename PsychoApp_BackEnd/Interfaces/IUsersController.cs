using Microsoft.AspNetCore.Mvc;
using psychoApp.Models;

namespace psychoApp.Interfaces
{
    public interface IUsersController
    {
        Task<ActionResult<IEnumerable<User>>> GetUsers(); // GET: api/Users
        Task<ActionResult<User>> GetUser(int id); // GET: api/Users/5
        Task<IActionResult> PutUser(int id, User user); // PUT: api/Users/5
        Task<ActionResult<User>> PostUser(User user); // POST: api/Users
        Task<IActionResult> Register(User user); // POST: api/Users/register
        Task<IActionResult> DeleteUser(int id); // DELETE: api/Users/5
        Task<ActionResult<IEnumerable<Note>>> GetUserNotes(int id); // GET: api/Notes/5
    }
}
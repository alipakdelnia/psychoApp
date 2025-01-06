using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psychoApp.Data;
using psychoApp.Interfaces;
using psychoApp.Models;

namespace psychoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase, INotesController
    {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetAllNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNoteByIdAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            return note == null ? NotFound(new { Success = false, message = "Note not found." }) : Ok(note);
        }


        [HttpPost]
        public async Task<ActionResult<Note>> CreateNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNoteByIdAsync), new { id = note.Id }, note);
        }

        [HttpPost("create-with-user")]
        public async Task<IActionResult> CreateNoteWithUserAsync(int userId, NoteDto noteDto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound(new { Success = false, message = "User not found." });
            }

            var note = new Note
            {
                Title = noteDto.Title,
                Content = noteDto.Content,
                CreateAt = noteDto.CreateAt,
                UserId = userId
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNoteByIdAsync), new { id = note.Id }, note);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNoteAsync(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest(new { Success = false, message = "Note ID mismatch." });
            }

            _context.Entry(note).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound(new { Success = false, message = "Note not found." });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { Success = true, message = "Note updated successfully.", note });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound(new { Success = false, message = "Note not found." });
            }

            note.IsDeleted = true;
            note.DeletedAt = DateTime.UtcNow;
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();

            return Ok(new { Success = true, message = "Note soft-deleted successfully." });
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}

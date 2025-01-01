using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psychoApp.Data;
using psychoApp.Models;
namespace psychoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context)
        {
            _context = context;
        }

        //Get : api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }
     

        //Get : api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if(note == null)
            {
                return NotFound(new { Success = false, message = "note not found!!!" });
            }

            return note;

        }

        //post : api/Notes
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.Id }, note);
            
        }

        //post 
        [HttpPost("create-note")]
        public async Task<IActionResult> CreateNote([FromQuery] int userId, [FromBody] NoteDto noteDto)
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

            return CreatedAtAction("GetNote", new { id = note.Id }, note);
        }


        //put : api/Notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id,Note note)
        {
            if (id != note.Id)  
            {
                return BadRequest(new { Success = false, message = "Note Id Mismatch..." });
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound(new { Success = false, message = "Note not found!" });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { Success = true, message = "note updated successfully.", note });

        }

        //Delete : api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote (int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound(new { Success = false, message = "note not found////" });
            }

            note.IsDeleted = true;
            note.DeletedAt = DateTime.UtcNow;

            _context.Notes.Update(note);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "note deleted ,,", });

        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using psychoApp.Models;

namespace psychoApp.Interfaces
{
    public interface INotesController
    {
 
        Task<ActionResult<IEnumerable<Note>>> GetAllNotesAsync(); // GET: api/Notes
        Task<ActionResult<Note>> GetNoteByIdAsync(int id);
        Task<ActionResult<Note>> CreateNoteAsync(Note note);
        Task<IActionResult> CreateNoteWithUserAsync(int userId, NoteDto noteDto);
        Task<IActionResult> UpdateNoteAsync(int id, Note note);
        Task<IActionResult> DeleteNoteAsync(int id);
    }
}
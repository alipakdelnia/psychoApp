using Microsoft.AspNetCore.Mvc;
using psychoApp.Models;

namespace psychoApp.Interfaces
{
    public interface INotesController
    {
        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns>200 Ok, List of all notes</returns>
        Task<ActionResult<IEnumerable<Note>>> GetAllNotesAsync(); // GET: api/Notes

        /// <summary>
        /// Get one note by id
        /// </summary>
        /// <param name="id">Id of note</param>
        /// <returns>200 Ok, note; 404 Not Found</returns>
        Task<ActionResult<Note>> GetNoteByIdAsync(int id);

        /// <summary>
        /// Create note
        /// </summary>
        /// <param name="note">Note to create</param>
        /// <returns>201 Created, note; 400 Bad Request</returns>
        Task<ActionResult<Note>> CreateNoteAsync(Note note);

        /// <summary>
        /// Create note with user
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <param name="noteDto">Note to create</param>
        /// <returns>201 Created, note; 400 Bad Request</returns>
        Task<IActionResult> CreateNoteWithUserAsync(int userId, NoteDto noteDto);

        /// <summary>
        /// Update note
        /// </summary>
        /// <param name="id">Id of note</param>
        /// <param name="note">Note to update</param>
        /// <returns>204 No Content; 400 Bad Request; 404 Not Found</returns>
        Task<IActionResult> UpdateNoteAsync(int id, Note note);

        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="id">Id of note</param>
        /// <returns>204 No Content; 404 Not Found</returns>
        Task<IActionResult> DeleteNoteAsync(int id);
    }
}
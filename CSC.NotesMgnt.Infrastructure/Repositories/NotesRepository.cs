using CSC.NotesMgnt.Domain.Entities;
using CSC.NotesMgnt.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.NotesMgnt.Infrastructure.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private BaseDbContext _dbContext;

        public NotesRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            return await _dbContext.Notes.AsNoTracking().OrderByDescending(k => k.ModifiedDate).ToListAsync();
        }

        public async Task<Note?> GetNoteByIdAsync(int Id)
        {
            return await _dbContext.Notes.FirstOrDefaultAsync(k => k.Id == Id);
        }

        public void CreateNote(Note note)
        {
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
        }

        public async Task<Note?> UpdateNoteAsync(Note noteToUpdate)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(k => k.Id == noteToUpdate.Id);

            if (note != null)
            {
                note.NoteText = noteToUpdate.NoteText;
                note.Title = noteToUpdate.Title;
                note.ModifiedDate = DateTime.Now;
                note.Priority = noteToUpdate.Priority;

                _dbContext.SaveChanges();
            }

            return note;            
        }

        public void DeleteNote(int Id)
        {
            var note = _dbContext.Notes.FirstOrDefault(k => k.Id == Id);
            if (note != null)
            { 
                _dbContext.Notes.Remove(note);
                _dbContext.SaveChanges();
            }
        }
    }
}

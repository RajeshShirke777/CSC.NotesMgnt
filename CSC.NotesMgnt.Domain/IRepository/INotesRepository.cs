using CSC.NotesMgnt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.NotesMgnt.Domain.IRepository
{
    public interface INotesRepository
    {
        Task<List<Note>> GetNotesAsync();
        Task<Note?> GetNoteByIdAsync(int Id);
        void CreateNote(Note note);
        Task<Note?> UpdateNoteAsync(Note note);
        void DeleteNote(int Id);
    }
}

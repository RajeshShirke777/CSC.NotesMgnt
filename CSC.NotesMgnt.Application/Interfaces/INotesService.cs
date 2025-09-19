using CSC.NotesMgnt.Application.DTOs;
using CSC.NotesMgnt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.NotesMgnt.Application.Interfaces
{
    public interface INotesService
    {
        Task<List<Note>> GetNotesAsync();

        Task<Note?> GetNoteByIdAsync(int id);

        void DeleteNote(int id);

        void CreateNote(NoteDTO noteDto);


        Task<Note> UpdateNoteAsync(int Id, Note note);
    }
}

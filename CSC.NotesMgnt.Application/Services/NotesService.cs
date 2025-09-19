using CSC.NotesMgnt.Application.DTOs;
using CSC.NotesMgnt.Application.Interfaces;
using CSC.NotesMgnt.Domain.Entities;
using CSC.NotesMgnt.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.NotesMgnt.Application.Services
{
    public class NotesService : INotesService
    {
        private INotesRepository _noteRepository;

        public NotesService(INotesRepository noteRepository) 
        {
            _noteRepository = noteRepository;
        }
        
        public async Task<List<Note>> GetNotesAsync()
        {

            return await _noteRepository.GetNotesAsync();

        }

        public async Task<Note?> GetNoteByIdAsync(int Id)
        {
            return await _noteRepository.GetNoteByIdAsync(Id);

        }

        public void CreateNote(NoteDTO noteDto)
        {
            var note = new Note()
            {
                Title = noteDto.Title,
                NoteText = noteDto.NoteText,
                Priority = noteDto.Priority
            }; 

            _noteRepository.CreateNote(note);
        }

        public async Task<Note?> UpdateNoteAsync(int Id, Note noteToUpdate)
        {
            var note = await _noteRepository.GetNoteByIdAsync(Id);

            if (note != null)
            {
                note = await _noteRepository.UpdateNoteAsync(noteToUpdate);
            }

            return note;
        }

        public void DeleteNote(int Id)
        {
            _noteRepository.DeleteNote(Id);
        }
    }
}

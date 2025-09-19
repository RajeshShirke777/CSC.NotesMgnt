using AutoMapper;
using CSC.NotesMgnt.Application.DTOs;
using CSC.NotesMgnt.Application.Interfaces;
using CSC.NotesMgnt.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CSC.NotesMgnt.Web.Controllers
{
    public class NotesController : Controller
    {
        private INotesService _notesService;
        private readonly IMapper _mapper;

        public NotesController(INotesService notesService, IMapper mapper)
        {
            _notesService = notesService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var notes = await _notesService.GetNotesAsync();
            
            return View(new UpdateNotesDTO() { Notes = _mapper.Map<List<NoteDTO>>(notes) });
        }

        public IActionResult Create()
        {
            var noteDto = new NoteDTO();
            return PartialView(noteDto);
        }

        [HttpPost]
        public IActionResult Create(NoteDTO noteDto)
        {
            if (ModelState.IsValid)
            {
                _notesService.CreateNote(noteDto);
                //return RedirectToAction("Index");
            }

            return View("CreateSuccess");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Note note)
        {
            if (ModelState.IsValid)
            {
                await _notesService.UpdateNoteAsync(note.Id, note);
                return View("UpdateSuccess");
            }

            return Json(new { success = false, message = "Errors in note data. Total errors " + ModelState.ErrorCount });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var note = await _notesService.GetNoteByIdAsync(Id);

            if (note != null)
            {
                _notesService.DeleteNote(Id);
                return Json(new { success = true, message = "Note deleted succesfully" });
            }
            else
            {
                return Json(new { success = false, message="Note does not found" });
            }
        }
    }
}

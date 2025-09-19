using AutoMapper;
using CSC.NotesMgnt.Application.DTOs;
using CSC.NotesMgnt.Domain.Entities;

namespace CSC.NotesMgnt.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Note, NoteDTO>();
        }    
    }
}

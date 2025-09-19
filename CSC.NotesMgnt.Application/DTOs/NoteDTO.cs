using CSC.NotesMgnt.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace CSC.NotesMgnt.Application.DTOs
{
    public class NoteDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? NoteText { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [NotMapped]
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public DateTime ModifiedDate { get; set; }

        public Dictionary<int, string> PriorityList { get; set; }

        public NoteDTO() 
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            PriorityList = new Dictionary<int, string>();

            int i = 1;
            foreach (var item in Enum.GetNames(typeof(Priority)).ToList())
            {
                PriorityList.Add(i, item);
                i++;
            }
        }
    }


    public class UpdateNotesDTO
    {
        public List<NoteDTO> Notes { get; set; }
        public NoteDTO Note { get; set; }
        public UpdateNotesDTO()
        {
            Notes = new List<NoteDTO>();
            Note = new NoteDTO();
        }
    }
}

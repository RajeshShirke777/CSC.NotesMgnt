using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.NotesMgnt.Domain.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? NoteText { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Note()
        {
            Id = 0;
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

    }
}

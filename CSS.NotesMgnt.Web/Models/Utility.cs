using CSC.NotesMgnt.Domain.Entities;

namespace CSC.NotesMgnt.Web.Models
{
    public static class Utility
    {
        public static string GetPriorityColor(Priority priority)
        {
            switch(priority)
            {
                case Priority.Low: return "#FFFFE0";
                case Priority.Medium: return "#ADD8E6";
                default: return "#90EE90";
            }
        }
    }
}

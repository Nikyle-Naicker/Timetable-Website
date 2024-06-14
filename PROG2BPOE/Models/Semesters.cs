using System.ComponentModel.DataAnnotations;

namespace PROG2BPOE.Models
{
    public class Semesters
    {
        [Key] public int SemesterID { get; set; }

        public DateTime StartDate { get; set; }

        public int NumWeeks { get; set; }

        public string Username { get; set; }
    }
}

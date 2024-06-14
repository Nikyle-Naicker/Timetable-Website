using System.ComponentModel.DataAnnotations;

namespace PROG2BPOE.Models
{
    public class Records
    {
        [Key]public int WeekID { get; set; }
        public string Username { get; set; }
        public int Week { get; set; }
        public int SelfStudy { get; set; }

        
    }
}

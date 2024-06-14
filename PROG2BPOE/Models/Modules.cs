using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG2BPOE.Models
{
    public class Modules
    {
        [Key] public int ModuleID { get; set; }

        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }

        public int Credits { get; set; }

        public int ClassHours { get; set; }

        public string Username { get; set; }

        //[ForeignKey] public string Email { get; set; }
    }
}

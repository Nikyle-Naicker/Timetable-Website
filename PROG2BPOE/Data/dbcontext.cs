using Microsoft.EntityFrameworkCore;
using PROG2BPOE.Models;

namespace PROG2BPOE.Data
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options) : base(options)
        {
            
        }
        //Gets sets of data from the sql tables 
        public DbSet<Modules> Module { get; set; }
        public DbSet<Semesters> Semester { get; set; }
        public DbSet<Records> Timetable { get; set; }
        public DbSet<Users> Student { get; set; }
    }
}

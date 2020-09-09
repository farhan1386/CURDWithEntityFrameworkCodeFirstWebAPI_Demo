using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models;
using System.Data.Entity;

namespace CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("StudentDB")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public System.Data.Entity.DbSet<CURDWithEntityFrameworkCodeFirstWebAPI_Demo.ViewModel.StudentViewModel> StudentViewModels { get; set; }
    }
}
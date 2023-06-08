using Microsoft.EntityFrameworkCore;

namespace StudentAdminPortal.API.DataModels
{
    public class StudentAdminContext :DbContext
    {
        //pass dbcontext options
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options):base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }

    }
}

namespace PrimeHoldingInternshipTask.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using Data.Models;

    public class EmployeesandtasksDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public EmployeesandtasksDbContext()
        {

        }

        public EmployeesandtasksDbContext(DbContextOptions<EmployeesandtasksDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0UU6PKA\SQLEXPRESS;Database=EmployeesAndTasks;Trusted_Connection=True;Encrypt=False;");
        }
    }
}

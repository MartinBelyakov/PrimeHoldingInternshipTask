namespace PrimeHoldingInternshipTask.Data
{
    using Microsoft.EntityFrameworkCore;

    using Data.Models;

    public class InternshipTaskDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Department> Departments { get; set; }

        public InternshipTaskDbContext()
        {

        }

        public InternshipTaskDbContext(DbContextOptions<InternshipTaskDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EmployeesAndTasks;Trusted_Connection=True;Encrypt=False;")
                .UseLazyLoadingProxies();
        }
    }
}

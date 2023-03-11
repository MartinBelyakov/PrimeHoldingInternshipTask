namespace PrimeHoldingInternshipTask.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal MonthlySalary { get; set; }

        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}

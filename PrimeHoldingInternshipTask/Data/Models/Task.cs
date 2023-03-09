namespace PrimeHoldingInternshipTask.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Asignee { get; set; }

        public DateTime DueDate { get; set; }
    }
}

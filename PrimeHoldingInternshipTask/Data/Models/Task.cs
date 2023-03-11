namespace PrimeHoldingInternshipTask.Data.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AsigneeId { get; set; }

        public virtual Employee Asignee { get; set; }

        public DateTime DueDate { get; set; }
    }
}

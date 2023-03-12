namespace PrimeHoldingInternshipTask.DisplayModels
{
    using System.Text;
    public class TaskDisplayModel
    {
        public TaskDisplayModel(string title, string description, int asigneeId, DateTime dueDate)
        {
            this.Title = title;
            this.Description = description;
            this.AsigneeId = asigneeId;
            this.DueDate = dueDate.ToString("dd.MM.yyyy");
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AsigneeId { get; set; }

        public string DueDate { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Title);
            sb.AppendLine(Description);
            sb.AppendLine(AsigneeId.ToString());
            sb.AppendLine(DueDate);

            return sb.ToString().TrimEnd();
        }
    }
}

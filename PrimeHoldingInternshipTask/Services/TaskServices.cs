namespace PrimeHoldingInternshipTask.Services
{
    using System.Globalization;

    using Data;
    using Data.Models;
    using DisplayModels;

    public class TaskServices
    {
        private readonly InternshipTaskDbContext data;
        public TaskServices()
        {
            this.data = new InternshipTaskDbContext();
        }

        public string CreateTask(string title, string description, string asigneeFullName, string dueDate)
        {
            var task = new Task
            {
                Title = title,
                Description = description,
                Asignee = this.data.Employees.FirstOrDefault(x => x.FullName == asigneeFullName),
                DueDate = DateTime.ParseExact(dueDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)
            };

            this.data.Tasks.Add(task);
            this.data.SaveChanges();

            return "Action was successful!";
        }

        public string UpdateTask(string title, string newTitle, string description, string asigneeFullName, string dueDate)
        {
            var task = this.data.Tasks.FirstOrDefault(x => x.Title == title);

            if (task == null)
            {
                return "Employee doesn't exist!";
            }

            task.Title = newTitle;
            task.Description = description;
            task.Asignee = this.data.Employees.FirstOrDefault(x => x.FullName == asigneeFullName);
            task.DueDate = DateTime.ParseExact(dueDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            this.data.SaveChanges();

            return "Action was successful!";
        }

        public string RemoveTask(string title)
        {
            var task = this.data.Tasks.FirstOrDefault(x => x.Title == title);

            if (task == null)
            {
                return "Employee doesn't exist!";
            }

            this.data.Tasks.Remove(task);
            this.data.SaveChanges();

            return "Action was successful!";
        }
        public string ReadTask(string title)
        {
            var task = data.Tasks.FirstOrDefault(x => x.Title == title);

            if (task == null)
            {
                return "Employee doesn't exist!";
            }

            var displayModelTask = new TaskDisplayModel
                (
                task.Title,
                task.Description,
                task.AsigneeId,
                task.DueDate
                );

            return displayModelTask.ToString();
        }
    }
}

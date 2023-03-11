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
        public TaskDisplayModel ReadTask(string title)
        {
            var searchedTask = data.Tasks.FirstOrDefault(x => x.Title == title);

            var displayModelTask = new TaskDisplayModel
                (
                searchedTask.Title,
                searchedTask.Description,
                searchedTask.AsigneeId,
                searchedTask.DueDate
                );

            return displayModelTask;
        }
        public void CreateTask(string title, string description, string asigneeFullName, string dueDate)
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
        }

        public void UpdateTask(string title, string newTitle, string description, string asigneeFullName, string dueDate)
        {

            var taskToUpdate = this.data.Tasks.FirstOrDefault(x => x.Title == title);

            taskToUpdate.Title = newTitle;
            taskToUpdate.Description = description;
            taskToUpdate.Asignee = this.data.Employees.FirstOrDefault(x => x.FullName == asigneeFullName);
            taskToUpdate.DueDate = DateTime.ParseExact(dueDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            this.data.SaveChanges();
        }

        public void RemoveTask(string title)
        {
            var taskToDelete = this.data.Tasks.FirstOrDefault(x => x.Title == title);

            this.data.Tasks.Remove(taskToDelete);
            this.data.SaveChanges();
        }
    }
}

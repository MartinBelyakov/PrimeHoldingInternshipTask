namespace PrimeHoldingInternshipTask.DisplayModels
{
    using System.Text;

    using Data.Models;

    public class EmployeeDisplayModel
    {
        public EmployeeDisplayModel(string fullName, string email, string number, DateTime dateOfBirth, decimal monthlySalary, List<Task> tasks)
        {
            this.FullName = fullName;
            this.Email = email;
            this.Number = number;
            this.DateOfBirth = dateOfBirth.ToString("dd.MM.yyyy");
            this.MonthlySalary = monthlySalary;
            this.Tasks = String.Join(", ", tasks.Select(x => x.Title));
        }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public string DateOfBirth { get; set; }

        public decimal MonthlySalary { get; set; }

        public string Tasks { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.FullName);
            sb.AppendLine(this.Email);
            sb.AppendLine(this.Number);
            sb.AppendLine(this.DateOfBirth);
            sb.AppendLine(this.MonthlySalary.ToString());
            sb.AppendLine(this.Tasks);

            return sb.ToString().TrimEnd();
        }

    }
}

namespace PrimeHoldingInternshipTask.DisplayModels
{
    using Data.Models;

    public class DepartmentDisplayModel
    {
        public DepartmentDisplayModel(string name, List<Employee> employees) 
        {
            this.Name = name;
            this.Employees = String.Join(", ", employees.Select(x => x.FullName));
        }

        public string Name { get; set; }

        public string Employees { get; set; }
    }
}

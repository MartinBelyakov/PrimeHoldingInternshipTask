namespace PrimeHoldingInternshipTask.Services
{
    using Data;
    using Data.Models;

    using System.Text;

    public class DepartmentService
    {
        private readonly InternshipTaskDbContext data;

        public DepartmentService()
        {
            this.data = new InternshipTaskDbContext();
        }

        public string CreateDepartment(string name)
        {
            var department = new Department
            {
                Name = name
            };

            this.data.Departments.Add(department);
            this.data.SaveChanges();

            return "Action was successful!";
        }

        public string ChangeEmployeeDepartment(string fullName, string departmentName)
        {
            var employee = this.data.Employees.FirstOrDefault(x => x.FullName == fullName);

            if (employee == null)
            {
                return "Employee doesn't exist!";
            }

            var department = this.data.Departments.FirstOrDefault(x => x.Name == departmentName);

            if (department == null)
            {
                return "The Department doesn't exist!";
            }

            employee.DepartmentId = department.Id;

            this.data.SaveChanges();

            return "Action was successful!";
        }

        public string ReadDepartment(string name)
        {
            var sb = new StringBuilder();

            var department = this.data.Departments.FirstOrDefault(x => x.Name == name);

            if (department == null)
            {
                return "The Department doesn't exist!";
            }

            sb.AppendLine(department.Name + ":");

            if (department.Employees.Any())
            {
                sb.AppendLine(String.Join(", ", department.Employees.Select(x => x.FullName)));
            }

            return sb.ToString().TrimEnd();
        }
    }
}

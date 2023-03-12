namespace PrimeHoldingInternshipTask.Services
{
    using System.Globalization;
    using System.Text;

    using Data;
    using Data.Models;
    using DisplayModels;

    public class EmployeeService
    {
        private readonly InternshipTaskDbContext data;
        public EmployeeService()
        {
            this.data = new InternshipTaskDbContext();
        }
        public string CreateEmployee(string fullName, string email, string phoneNumber, string dateOfBirth, decimal monthlySalary, string departmentName)
        {
            var department = this.data.Departments.FirstOrDefault(x => x.Name == departmentName);

            if ( department == null)
            {
                return "Department doesn't exist!";
            }

            var employee = new Employee
            {
                FullName = fullName,
                Email = email,
                Number = phoneNumber,
                DateOfBirth = DateTime.ParseExact(dateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                MonthlySalary = monthlySalary,
                DepartmentId = department.Id
            };

            this.data.Employees.Add(employee);
            this.data.SaveChanges();

            return "Action was successful!";
        }

        public string UpdateEmployee(string fullName, string newFullName, string email, string phoneNumber, string dateOfBirth, decimal monthlySalary)
        {
            var employee = this.data.Employees.FirstOrDefault(x => x.FullName == fullName);

            if (employee == null)
            {
                return "Employee doesn't exist!";
            }

            employee.FullName = newFullName;
            employee.Email = email;
            employee.Number = phoneNumber;
            employee.DateOfBirth = DateTime.ParseExact(dateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            employee.MonthlySalary = monthlySalary;

            this.data.SaveChanges();

            return "Action was successful!";
        }

        public string DeleteEmployee(string fullName)
        {
            var employee = this.data.Employees.FirstOrDefault(x => x.FullName == fullName);

            if (employee == null)
            {
                return "Employee doesn't exist!";
            }

            this.data.Employees.Remove(employee);
            this.data.SaveChanges();

            return "Action was successful!";
        }

        public string ReadEmployee(string fullName)
        {
            var employee = this.data.Employees.FirstOrDefault(x => x.FullName == fullName);

            if (employee == null)
            {
                return "Employee doesn't exist!";
            }

            var employeeDisplayModel = new EmployeeDisplayModel
                (
                employee.FullName,
                employee.Email,
                employee.Number,
                employee.DateOfBirth,
                employee.MonthlySalary,
                employee.Department.Name,
                employee.Tasks.ToList()
                );

            return employeeDisplayModel.ToString();
        }

        public string ReturnTopFiveEmployees()
        {
            var employees = this.data.Employees;
            var sb = new StringBuilder();

            var now = DateTime.Now;
            var lastMonth = now.AddMonths(-1);

            var employeesWithCompletedTasksLastMonth = employees
                .Where(e => e.Tasks.Any(t => t.DueDate >= lastMonth && t.DueDate <= now)).ToList();

            var top5EmployeesWithMostCompletedTasks = employeesWithCompletedTasksLastMonth
                .OrderByDescending(e => e.Tasks.Count(t => t.DueDate >= lastMonth && t.DueDate <= now)).Take(5).ToList();

            foreach (var emp in top5EmployeesWithMostCompletedTasks)
            {
                sb.AppendLine($"{emp.FullName} - {emp.Tasks.Count}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

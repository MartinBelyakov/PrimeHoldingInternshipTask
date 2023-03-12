namespace PrimeHoldingInternshipTask.Services
{
    using System.Globalization;
    using System.Text;
    using Castle.Components.DictionaryAdapter.Xml;
    using Data;
    using Data.Models;
    using DisplayModels;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeService
    {
        private readonly InternshipTaskDbContext data;
        public EmployeeService()
        {
            this.data = new InternshipTaskDbContext();
        }
        public void CreateEmployee(string fullName, string email, string phoneNumber, string dateOfBirth, decimal monthlySalary)
        {
            var employee = new Employee
            {
                FullName = fullName,
                Email = email,
                Number = phoneNumber,
                DateOfBirth = DateTime.ParseExact(dateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                MonthlySalary = monthlySalary
            };

            this.data.Employees.Add(employee);
            this.data.SaveChanges();
        }

        public void UpdateEmployee(string fullName, string newFullName, string email, string phoneNumber, string dateOfBirth, decimal monthlySalary)
        {
            var employee = this.data.Employees.FirstOrDefault(x => x.FullName == fullName);

            employee.FullName = newFullName;
            employee.Email = email;
            employee.Number = phoneNumber;
            employee.DateOfBirth = DateTime.ParseExact(dateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            employee.MonthlySalary = monthlySalary;

            this.data.SaveChanges();
        }

        public void DeleteEmployee(string fullName)
        {
            var employee = this.data.Employees.FirstOrDefault(x => x.FullName == fullName);

            this.data.Employees.Remove(employee);
            this.data.SaveChanges();
        }

        public EmployeeDisplayModel ReadEmployee(string fullName)
        {
            var searchedEmployee = this.data.Employees.FirstOrDefault(x => x.FullName == fullName);

            var employeeDisplayModel = new EmployeeDisplayModel
                (
                searchedEmployee.FullName,
                searchedEmployee.Email,
                searchedEmployee.Number,
                searchedEmployee.DateOfBirth,
                searchedEmployee.MonthlySalary,
                searchedEmployee.Tasks.ToList()
                );

            return employeeDisplayModel;
        }

        public string ReturnTopFiveEmployees()
        {

            var employees = this.data.Employees;
            var sb = new StringBuilder();

            var now = DateTime.Now;
            var lastMonth = now.AddMonths(-1);
            var employeesWithCompletedTasksLastMonth = employees.Where(e => e.Tasks.Any(t => t.DueDate >= lastMonth && t.DueDate <= now)).ToList();

            var top5EmployeesWithMostCompletedTasks = employeesWithCompletedTasksLastMonth.OrderByDescending(e => e.Tasks.Count(t => t.DueDate >= lastMonth && t.DueDate <= now)).Take(5).ToList();

            foreach (var emp in top5EmployeesWithMostCompletedTasks)
            {
                sb.AppendLine($"{emp.FullName} - {emp.Tasks.Count}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}

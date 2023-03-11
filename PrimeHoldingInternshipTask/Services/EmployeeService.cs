namespace PrimeHoldingInternshipTask.Services
{
    using System.Globalization;

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
    }
}

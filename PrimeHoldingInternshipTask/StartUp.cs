namespace PrimeHoldingInternshipTask
{
    using Services;

    public class StartUp
    {
        static void Main()
        {
            var employeeService = new EmployeeService();
            var taskServices = new TaskServices();

            while (true)
            {
                Console.WriteLine("What action will you perform?");

                var action = Console.ReadLine();

                if (action == "Exit")
                {
                    return;
                }
                else if (action == "Read Employee")
                {
                    Console.WriteLine("Full name:");
                    var fullName = Console.ReadLine();

                    var employee = employeeService.ReadEmployee(fullName);

                    Console.WriteLine(employee.ToString());
                }
                else if (action == "Read Task")
                {
                    Console.WriteLine("Title:");
                    var title = Console.ReadLine();

                    var task = taskServices.ReadTask(title);
                    Console.WriteLine(task.ToString());
                }
                else if (action == "Add Employee")
                {
                    Console.WriteLine("Full name:");
                    var fullName = Console.ReadLine();

                    Console.WriteLine("Email:");
                    var email = Console.ReadLine();

                    Console.WriteLine("Phone number:");
                    var phoneNumber = Console.ReadLine();

                    Console.WriteLine("Date of birth(\"dd.MM.yyyy\"):");
                    var dateOfBirth = Console.ReadLine();

                    Console.WriteLine("Montlhy salary:");
                    var monthlySalary = decimal.Parse(Console.ReadLine());

                    employeeService.CreateEmployee(fullName, email, phoneNumber, dateOfBirth, monthlySalary);
                }
                else if (action == "Update Employee")
                {
                    Console.WriteLine("Full name:");
                    var fullName = Console.ReadLine();

                    Console.WriteLine("New full name:");
                    var newFullName = Console.ReadLine();

                    Console.WriteLine("New email:");
                    var newEmail = Console.ReadLine();

                    Console.WriteLine("New phone number:");
                    var newPhoneNumber = Console.ReadLine();

                    Console.WriteLine("New date of birth(\"dd.MM.yyyy\"):");
                    var newDateOfBirth = Console.ReadLine();

                    Console.WriteLine("New montlhy salary:");
                    var newMonthlySalary = decimal.Parse(Console.ReadLine());

                    employeeService.UpdateEmployee(fullName, newFullName, newEmail, newPhoneNumber, newDateOfBirth, newMonthlySalary);

                }
                else if (action == "Delete Employee")
                {
                    Console.WriteLine("Full name:");
                    var fullname = Console.ReadLine();

                    employeeService.DeleteEmployee(fullname);
                }
                else if (action == "Add Task")
                {
                    Console.WriteLine("Title:");
                    var title = Console.ReadLine();

                    Console.WriteLine("Description:");
                    var description = Console.ReadLine();

                    Console.WriteLine("Asignee full name:");
                    var asigneeFullName = Console.ReadLine();

                    Console.WriteLine("Due date(\"dd.MM.yyyy\"):");
                    var dueDate = Console.ReadLine();

                    taskServices.CreateTask(title, description, asigneeFullName, dueDate);
                }
                else if (action == "Update Task")
                {
                    Console.WriteLine("Title:");
                    var title = Console.ReadLine();

                    Console.WriteLine("New title:");
                    var newTitle = Console.ReadLine();

                    Console.WriteLine("New description:");
                    var newDescription = Console.ReadLine();

                    Console.WriteLine("New asignee full name:");
                    var newAsigneeFullName = Console.ReadLine();

                    Console.WriteLine("New due date(\"dd.MM.yyyy\"):");
                    var newDueDate = Console.ReadLine();

                    taskServices.UpdateTask(title, newTitle, newDescription, newAsigneeFullName, newDueDate);
                }
                else if (action == "Delete Task")
                {
                    Console.WriteLine("Title:");
                    var title = Console.ReadLine();

                    taskServices.RemoveTask(title);

                }
                else if (action == "Display top 5 employees")
                {
                    var employees = employeeService.ReturnTopFiveEmployees();
                    Console.WriteLine(employees);
                }
                else
                {
                    Console.WriteLine("No such action");
                }
            }
        }
    }
}
namespace PrimeHoldingInternshipTask
{
    using Services;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            var employeeService = new EmployeeService();
            var taskServices = new TaskServices();
            var departmentServices = new DepartmentService();

            var sb = new StringBuilder();

            sb.AppendLine("What action will you perform?");
            sb.AppendLine("The options are listed below:");
            sb.AppendLine("-Read Employee");
            sb.AppendLine("-Add Employee");
            sb.AppendLine("-Update Employee");
            sb.AppendLine("-Delete Employee");
            sb.AppendLine("-Display top 5 employees");
            sb.AppendLine("-Read Task");
            sb.AppendLine("-Add Task");
            sb.AppendLine("-Update Task");
            sb.AppendLine("-Delete Task");
            sb.AppendLine("-Add Department");
            sb.AppendLine("-Read Department");
            sb.AppendLine("-Change Employee Department");
            sb.AppendLine("-Exit");

            Console.WriteLine(sb.ToString().TrimEnd());

            while (true)
            {
                Console.WriteLine("Enter your choice:");

                var action = Console.ReadLine().ToLower();

                if (action == "exit")
                {
                    return;
                }
                else if (action == "read employee")
                {
                    Console.WriteLine("Full name:");
                    var fullName = Console.ReadLine();

                    var employee = employeeService.ReadEmployee(fullName);

                    Console.WriteLine(employee);
                }
                else if (action == "read task")
                {
                    Console.WriteLine("Title:");
                    var title = Console.ReadLine();

                    var task = taskServices.ReadTask(title);
                    Console.WriteLine(task);
                }
                else if (action == "add employee")
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

                    Console.WriteLine("Department Name");
                    var departmentName = Console.ReadLine();

                    var result = employeeService.CreateEmployee(fullName, email, phoneNumber, dateOfBirth, monthlySalary, departmentName);
                    Console.WriteLine(result);
                }
                else if (action == "update employee")
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

                    var result = employeeService.UpdateEmployee(fullName, newFullName, newEmail, newPhoneNumber, newDateOfBirth, newMonthlySalary);
                    Console.WriteLine(result);
                }
                else if (action == "delete employee")
                {
                    Console.WriteLine("Full name:");
                    var fullname = Console.ReadLine();

                    var result = employeeService.DeleteEmployee(fullname);
                    Console.WriteLine(result);
                }
                else if (action == "add task")
                {
                    Console.WriteLine("Title:");
                    var title = Console.ReadLine();

                    Console.WriteLine("Description:");
                    var description = Console.ReadLine();

                    Console.WriteLine("Asignee full name:");
                    var asigneeFullName = Console.ReadLine();

                    Console.WriteLine("Due date(\"dd.MM.yyyy\"):");
                    var dueDate = Console.ReadLine();

                    var result = taskServices.CreateTask(title, description, asigneeFullName, dueDate);
                    Console.WriteLine(result);
                }
                else if (action == "update task")
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

                    var result = taskServices.UpdateTask(title, newTitle, newDescription, newAsigneeFullName, newDueDate);
                    Console.WriteLine(result);
                }
                else if (action == "delete task")
                {
                    Console.WriteLine("Title:");
                    var title = Console.ReadLine();

                    var result = taskServices.RemoveTask(title);
                    Console.WriteLine(result);
                }
                else if (action == "display top 5 employees")
                {
                    var employees = employeeService.ReturnTopFiveEmployees();

                    Console.WriteLine(employees);
                }
                else if (action == "add department")
                {
                    Console.WriteLine("Department Name:");
                    var name = Console.ReadLine();

                    var result = departmentServices.CreateDepartment(name);
                    Console.WriteLine(result);
                }
                else if (action == "read department")
                {
                    Console.WriteLine("Department Name:");
                    var name = Console.ReadLine();

                    var result = departmentServices.ReadDepartment(name);
                    Console.WriteLine(result);
                }
                else if (action == "change employee department")
                {
                    Console.WriteLine("Employee FullName:");
                    var employeeFullName = Console.ReadLine();

                    Console.WriteLine("Department Name");
                    var departmentName = Console.ReadLine();

                    var result = departmentServices.ChangeEmployeeDepartment(employeeFullName, departmentName);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("No such action");
                }
            }
        }
    }
}
namespace A1JainiTopiwala
{
    internal class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            employees.Add(new SalariedEmployee(101, "Jaini", 3000m, 500m));
            employees.Add(new SalariedEmployee(102, "Hazel", 3200m, 300m));
            employees.Add(new SalariedEmployee(103, "Nikolai", 4000m, 300m));
            employees.Add(new SalariedEmployee(104, "paul", 3600m, 400m));
            employees.Add(new SalariedEmployee(105, "Meghan", 5600m, 100m));
            employees.Add(new CommissionBasedEmployee(106, "Aspin", 50000m, 0.1m));
            employees.Add(new CommissionBasedEmployee(107, "Ethan", 60000m, 0.15m));
            employees.Add(new CommissionBasedEmployee(108, "Anna", 35000m, 0.12m));
            employees.Add(new CommissionBasedEmployee(109, "Wael", 42000m, 0.2m));
            employees.Add(new CommissionBasedEmployee(110, "Noah", 30000m, 0.25m));

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("Pick your option:");
                Console.WriteLine("1: Delete an Employee");
                Console.WriteLine("2: View All Salary Based Employees");
                Console.WriteLine("3: View All Commission Based Employees");
                Console.WriteLine("4: Search an Employee By Name");
                Console.WriteLine("5: Exit");
                Console.WriteLine("----------------------------------------");
                Console.Write("Enter your Choice here: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        DeleteEmployee();
                        break;
                    case 2:
                        ViewSalariedEmployees();
                        break;
                    case 3:
                        ViewCommissionBasedEmployees();
                        break;
                    case 4:
                        SearchEmployeeByName();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void DeleteEmployee()
        {
            Console.WriteLine("Name\tId");
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeName}\t{emp.EmployeeId}");
            }

            Console.WriteLine("\nEnter Id of Employee to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("DELETED");

                Console.WriteLine("Name\tId");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.EmployeeName}\t{emp.EmployeeId}");
                }
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }


        static void ViewSalariedEmployees()
        {
            var salariedEmployees = employees.OfType<SalariedEmployee>();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Name", "Id", "Monthly Salary", "Incentives", "Total Earning");
            foreach (var emp in salariedEmployees)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", emp.EmployeeName, emp.EmployeeId, emp.MonthlySalary, emp.MonthlyIncentive, emp.Earnings());
            }
        }


        static void ViewCommissionBasedEmployees()
        {
            var commissionBasedEmployees = employees.OfType<CommissionBasedEmployee>();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Name", "Id", "Sales Amount", "Commission Rate", "Total Earning");
            foreach (var emp in commissionBasedEmployees)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20:P} {4,-20}", emp.EmployeeName, emp.EmployeeId, emp.SalesAmount, emp.CommissionRate, emp.Earnings());
            }
        }

        static void SearchEmployeeByName()
        {
            Console.WriteLine("Enter Name of Employee:");
            string name = Console.ReadLine();
            var foundEmployees = employees.Where(e => e.EmployeeName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (foundEmployees.Any())
            {
                Console.WriteLine("\nFound Employees:");
                Console.WriteLine("Name\tId\tEarnings");
                foreach (var emp in foundEmployees)
                {
                    Console.WriteLine($"{emp.EmployeeName}\t{emp.EmployeeId}\t{emp.Earnings()}");
                }
            }
            else
            {
                Console.WriteLine("No employees found with that name.");
            }
        }

    }
}

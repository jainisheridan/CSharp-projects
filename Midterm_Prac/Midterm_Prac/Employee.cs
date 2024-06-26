using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Prac
{
    abstract class Employee
    {
        public EmployeeType EmployeeType { get; private set; }
        public string EmployeeName { get; set; }

        public Employee(string name, EmployeeType type)
        {
            EmployeeName = name;
            EmployeeType = type;
        }

        public abstract decimal GrossEarnings { get; }
    }
}

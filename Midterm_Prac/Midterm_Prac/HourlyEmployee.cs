using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Prac
{
    class HourlyEmployee : Employee
    {
        public decimal Hours { get; set; }
        public decimal Wage { get; set; }

        public HourlyEmployee(string name, decimal hours, decimal wage)
            : base(name, EmployeeType.HourlyEmployee)
        {
            Hours = hours;
            Wage = wage;
        }

        public override decimal GrossEarnings => Hours * Wage;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1JainiTopiwala
{
    internal class SalariedEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyIncentive { get; set; }

        public SalariedEmployee(int id, string name, decimal monthlySalary, decimal monthlyIncentive)
            : base(EmployeeType.Salaried, id, name)
        {
            MonthlySalary = monthlySalary;
            MonthlyIncentive = monthlyIncentive;
        }

        public override decimal Earnings()
        {
            return MonthlySalary + MonthlyIncentive;
        }
    }
}

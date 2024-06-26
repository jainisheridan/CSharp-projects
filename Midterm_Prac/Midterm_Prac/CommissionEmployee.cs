using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Prac
{
    class CommissionEmployee : Employee
    {
        public decimal Sales { get; set; }
        public decimal Rate { get; set; }

        public CommissionEmployee(string name, decimal sales, decimal rate)
            : base(name, EmployeeType.CommissionEmployee)
        {
            Sales = sales;
            Rate = rate;
        }

        public override decimal GrossEarnings => Sales * Rate;
    }
}

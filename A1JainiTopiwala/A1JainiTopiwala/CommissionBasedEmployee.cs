using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1JainiTopiwala
{
    internal class CommissionBasedEmployee : Employee
    {
        public decimal SalesAmount { get; set; }
        public decimal CommissionRate { get; set; } 

        public CommissionBasedEmployee(int id, string name, decimal salesAmount, decimal commissionRate)
            : base(EmployeeType.CommissionBased, id, name)
        {
            SalesAmount = salesAmount;
            CommissionRate = commissionRate;
        }

        public override decimal Earnings()
        {
            return CommissionRate * SalesAmount;
        }
    }
}

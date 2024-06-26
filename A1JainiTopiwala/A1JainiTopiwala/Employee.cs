using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1JainiTopiwala
{
    public enum EmployeeType
    {
        CommissionBased,
        Salaried
    }
    internal abstract class Employee
    {
        public EmployeeType Type { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        protected Employee(EmployeeType type, int id, string name)
        {
            Type = type;
            EmployeeId = id;
            EmployeeName = name;
        }

        public abstract decimal Earnings();
    }
}

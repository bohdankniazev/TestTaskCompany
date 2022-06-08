using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCompany
{
    public class Company
    {
        public Company(CompanyConfig config)
        {
            _employees = new List<BaseEmployee>();
            _config = config;
        }

        private CompanyConfig _config;
        private List<BaseEmployee> _employees;

        public enum JobPosition
        {
            Employee = 0,
            Sales = 1,
            Manager = 2
        }

        public void CreateEmployee(string name, string bossName, DateTime entryDate, JobPosition jobPosition)
        {
            BaseEmployee head = FindEmployee(bossName);
            switch (jobPosition)
            {
                case JobPosition.Employee:
                    Employee employee = new Employee(name, entryDate, _config);                   
                    AddEmployee(employee, head);
                    break;
                case JobPosition.Sales:
                    Sales sales = new Sales(name, entryDate, _config);
                    AddEmployee(sales, head);
                    break;
                case JobPosition.Manager:
                    Manager manager = new Manager(name, entryDate, _config);
                    AddEmployee(manager, head);
                    break;
            }       

        }

        public void AddEmployee(BaseEmployee employee, BaseEmployee head)
        {
            _employees.Add(employee);
            employee.Head = head;
            if(head != null)
                head.Employees.Add(employee);
        }

        public BaseEmployee FindEmployee(string name)
        {
            return _employees.Find(empl => empl.Name == name);
        }

        public void DeleteEmployee(string name, BaseEmployee newEmployeesHead)
        {
            BaseEmployee employee = _employees.Find(empl => empl.Name == name);
            foreach(BaseEmployee empl in employee.Employees)
            {
                empl.Head = newEmployeesHead;
                newEmployeesHead.Employees.Add(empl);
            }
            if(employee.Head != null)
            {
                employee.Head.Employees.Remove(employee);
            }
        }

        public double SumOfSalaries()
        {
            return _employees.Sum(empl => empl.Salary);
        }
    }
}

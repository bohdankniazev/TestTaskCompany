using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCompany
{
    public abstract class BaseEmployee
    {
        public BaseEmployee(string name, DateTime entryDate, IConfig config)
        {
            Name = name;
            EntryDate = entryDate;
            _config = config;
        }

        protected IConfig _config;

        public double Salary
        {
            get
            {
                return BaseRate + GetBonus();
            }
        }
        public int TotalYears
        {
            get { return (int)((DateTime.Now - EntryDate).TotalDays / 365); }
        }

        public BaseEmployee Head { get; set; }

        public string Name { get; set; }

        public DateTime EntryDate { get; set; }

        public double BaseRate
        {
            get
            {
                string value = _config.GetValue("BASE_RATE");
                if (double.TryParse(value, out double result))
                    return result;
                else
                    return 0;
            }
        }

        private List<BaseEmployee>  _employees = new List<BaseEmployee>();

        public List<BaseEmployee> Employees { get { return _employees; } }


        protected void GetAllUnderEmployees(BaseEmployee employee, List<BaseEmployee> employees)
        {
            if (employee.Employees.Count == 0)
                return;
            else
            {
                foreach(BaseEmployee empl in employee.Employees)
                {
                    employees.Add(empl);
                    GetAllUnderEmployees(empl, employees);
                }
            }
        }

        protected abstract double GetBonus();
    }

}

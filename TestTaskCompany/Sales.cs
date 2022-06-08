using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCompany
{
    public class Sales : BaseEmployee
    {
        public Sales(string name, DateTime entryDate, IConfig config)
           : base(name, entryDate, config) { }

        public double BonusYearsRate
        {
            get
            {
                string value = _config.GetValue("SALES_BONUS_YEARS_RATE");
                if (double.TryParse(value, out double result))
                    return result;
                else
                    return 0;
            }
        }

        public double BonusPersonsRate
        {
            get
            {
                string value = _config.GetValue("SALES_BONUS_PERSONS_RATE");
                if (double.TryParse(value, out double result))
                    return result;
                else
                    return 0;
            }
        }

        public double MaxRate
        {
            get
            {
                string value = _config.GetValue("SALES_MAX_BONUS_RATE");
                if (double.TryParse(value, out double result))
                    return result;
                else
                    return 0;
            }
        }

        protected override double GetBonus()
        {
            double Bonus1 = TotalYears * BonusYearsRate * BaseRate;
            Bonus1 = Bonus1 < BaseRate * MaxRate ? Bonus1 : BaseRate * MaxRate;
            var underEmployees = new List<BaseEmployee>();
            GetAllUnderEmployees(this, underEmployees);
            double Bonus2 = underEmployees.Sum(empl => empl.Salary) * BonusPersonsRate;
            return Bonus1 + Bonus2;
        }
    }
}

using System;
using System.Collections.Generic;


namespace TaskCompany
{
    public class Employee : BaseEmployee
    {
        public Employee(string name, DateTime entryDate, IConfig config)
           : base(name, entryDate, config)
        {
        }

        public double BonusRate
        {
            get
            {
                string value = _config.GetValue("EMPL_BONUS_RATE");
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
                string value = _config.GetValue("EMPL_MAX_BONUS_RATE");
                if (double.TryParse(value, out double result))
                    return result;
                else
                    return 0;
            }
        }

        protected override double GetBonus()
        {
            double Bonus = TotalYears * BonusRate * BaseRate;
            return Bonus < BaseRate * MaxRate ? Bonus : BaseRate * MaxRate;
        }
    }
}

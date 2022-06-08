using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCompany
{
    public class CompanyConfig : IConfig
    {
        public CompanyConfig()
        {
            _configValues = new Dictionary<string, string>();
            Initialize();
        }

        private Dictionary<string, string> _configValues;

        public void Initialize()
        {
            _configValues.Add("BASE_RATE", "10000");

            _configValues.Add("EMPL_MAX_BONUS_RATE", "0.3");
            _configValues.Add("EMPL_BONUS_RATE", "0.03");

            _configValues.Add("MANAGER_MAX_BONUS_RATE", "0.4");
            _configValues.Add("MANAGER_BONUS_PERSONS_RATE", "0.005");
            _configValues.Add("MANAGER_BONUS_YEARS_RATE", "0.05");

            _configValues.Add("SALES_BONUS_YEARS_RATE", "0.01");
            _configValues.Add("SALES_BONUS_PERSONS_RATE", "0.003");
            _configValues.Add("SALES_MAX_BONUS_RATE", "0.35");
        }

        public string GetValue(string key)
        {
            string value = string.Empty;
            _configValues.TryGetValue(key, out value);
            return value;
        }
    }
}

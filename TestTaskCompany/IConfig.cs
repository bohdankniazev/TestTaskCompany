using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCompany
{
    public interface IConfig
    {
        string GetValue(string key);
    }
}

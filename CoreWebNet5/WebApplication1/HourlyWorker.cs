using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class HourlyWorker : Worker
    {
        public HourlyWorker(int annualSalary)
            : base(annualSalary)
        {
            salary = annualSalary;//Verify constructor of a base class
        }
    }
}

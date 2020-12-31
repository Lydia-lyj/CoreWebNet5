using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Worker
    {
        public int salary;

        public Worker(int annualSalary)
        {
            salary = annualSalary; //Verify constructor for a parameter
        }

        public Worker(int weeklySalary, int numberOfWeeks)
        {
            salary = weeklySalary * numberOfWeeks;//Verify constructor for two parameters
        }
    }
}

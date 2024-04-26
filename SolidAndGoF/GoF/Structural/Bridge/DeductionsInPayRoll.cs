using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Structural.Bridge
{
    /// <summary>
    /// It allows you to divide a large class, or a group of closely related classes, into two separate hierarchies (abstraction and implementation) that can be developed independently of each other.
    /// </summary>
    public class DeductionsInPayRoll
    {
        public abstract class Employee
        {
           IPayRollHandler _payRollHandler;
            public string Name { get; set; }
            public double Salary { get; set; }
            public double RateDeduction { get; set; }
            public double Deduction { get; set; }
            public double TotalSalary { get; set; }

            //new
            public Employee(IPayRollHandler payRollHandler)
            {
                _payRollHandler = payRollHandler;
            }

            public void GetPayRoll()
            {
                Deduction = _payRollHandler.CalculateDeduction(Salary, RateDeduction);
                TotalSalary = _payRollHandler.GetTotalSalary(Salary, RateDeduction);
                Console.WriteLine($"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}");
            }
        }

        //Decopling >>>
        public interface IPayRollHandler
        {

            double CalculateDeduction(double salary, double rate);

            double GetTotalSalary(double salary, double rate);
        }

        public class PayRollHandler : IPayRollHandler
        {
            public string Rol { get; set; }
            public double CalculateDeduction(double salary, double rate) => (salary * rate) ;
            public double GetTotalSalary(double salary, double rate) => salary - CalculateDeduction(salary, rate);
        }
        //Decopling <<<

        public class Devleloper : Employee
        {

            public Devleloper(IPayRollHandler payRollHandler) : base(payRollHandler)
            {
                Salary = 2000;
                RateDeduction = 0.1;
      
            }

            /* Decopling
                public double CalculateDeduction(double salary, double rate) => (salary * rate) / 100;
                public double GetTotalSalary(double salary, double rate) => salary - CalculateDeduction(salary, rate);
             */
        }

        public class ScrumMaster : Employee
        {
            public ScrumMaster(IPayRollHandler payRollHandler) : base(payRollHandler)
            {
                Salary = 1800;
                RateDeduction = 0.08;
            }

            /* Decopling
              public double CalculateDeduction(double salary, double rate) => (salary * rate) / 100;
              public double GetTotalSalary(double salary, double rate) => salary - CalculateDeduction(salary, rate);
           */
        }

    }
}

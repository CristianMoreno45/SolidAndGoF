using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolidAndGoF.SOLID.DepndencyInjection.ClassToRefactor;

namespace SolidAndGoF.SOLID.DepndencyInjection
{
    public class ClassToRefactor
    {
        public enum Role
        {
            Excecutive,
            Manager,
            Tactic,
            Operative
        }
        public enum Genere
        {
            Female,
            Male,
            Other
        }
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Genere Genere { get; set; }
            public Role Role { get; set; }
            public double Salary { get; set; }
        }

        public class EmployManager
        {
            private readonly List<Employee> _employees = new List<Employee>();

            //This property is used to share the resource, but when this resource is changed, its dependencies will have to change in the same way.
            public List<Employee> Employees => _employees;

            public void Save(Employee employee)
            {
                _employees.Add(employee);
            }
        }

        public class EmploySearch
        {
            private readonly EmployManager _employManager;

            public EmploySearch(EmployManager employManager)
            {
                _employManager = employManager;
            }
            public int GetCountMaleExcecutives()
            {
                return _employManager
                    .Employees
                    .Where(e => e.Role == Role.Excecutive && e.Genere == Genere.Male)
                    .ToList()
                    .Count();
            }
        }
    }
}

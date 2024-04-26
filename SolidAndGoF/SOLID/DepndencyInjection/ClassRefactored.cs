using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolidAndGoF.SOLID.DepndencyInjection.ClassRefactored;

namespace SolidAndGoF.SOLID.DepndencyInjection
{
    public class ClassRefactored
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

        // define a interface whit the specific function
        public interface IEmploySearchable
        {
            public int CountEmployeeByGenderAndRole(Role role, Genere genere);
        }


        public class EmployManager : IEmploySearchable
        {
            private readonly List<Employee> _employees = new List<Employee>();
            public List<Employee> Employees => _employees;

            public void Save(Employee employee)
            {
                _employees.Add(employee);
            }
            public int CountEmployeeByGenderAndRole(Role role, Genere genere)
            {
                return _employees
                    .Where(e => e.Role == role && e.Genere == genere)
                    .ToList()
                    .Count();
            }
        }

        public class EmploySearch
        {
            private readonly IEmploySearchable _employSearchable;

            public EmploySearch(IEmploySearchable employSearchable)
            {
                _employSearchable = employSearchable;
            }
            public int GetCountMaleExcecutives()
            {
                return _employSearchable.CountEmployeeByGenderAndRole(Role.Excecutive, Genere.Male);
            }
        }
    }
}

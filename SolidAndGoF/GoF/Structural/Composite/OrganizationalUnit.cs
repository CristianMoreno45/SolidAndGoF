using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Structural.Composite
{
    /// <summary>
    /// It allows you to compose objects into tree structures and work with those structures as if they were individual objects.
    /// </summary>
    public class OrganizationalUnit
    {
        public abstract class Employee
        {
            protected Employee(string name, int salary)
            {
                Name = name;
                Salary = salary;
            }

            public string Name { get; private set; }
            public int Salary { get; private set; }

            public abstract void AddMember(Employee employee);
            public abstract void RemoveMember(Employee employee);

            public abstract int GetCost();
        }

        public class TeamMember : Employee
        {
            public TeamMember(string name, int salary) : base(name, salary) { }
            public override void AddMember(Employee employee) { }
            public override void RemoveMember(Employee employee) { }
            public override int GetCost() => Salary;
        }
        public class TeamLead : Employee
        {
            private List<Employee> _team = new List<Employee>();
            public TeamLead(string name, int salary) : base(name, salary) {
                _team.Add(this);
            }
            public override void AddMember(Employee employee)
            {
                _team.Add(employee);
            }
            public override void RemoveMember(Employee employee)
            {
                _team.Remove(employee);
            }
            public override int GetCost() => _team.Sum(e => e.Salary);
        }
    }
}

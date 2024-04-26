using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Structural.Proxy
{
    public class Restaurant
    {
        public class Person
        {
            public Person(int balance)
            {
                Balance = balance;
            }

            public int Balance { get; set; }

            public string Eat()
            {
                return "I am eating";
            }

        }

        public class ProxyPerson
        {
            private readonly Person person;

            public ProxyPerson(Person person)
            {
                this.person = person;
            }

            public string Eat()
            {
                if (person.Balance > 0)
                    return person.Eat();
                return "I don't have money";
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Creational.FactoryMethod
{
    /// <summary>
    /// Provides an interface for creating objects in a superclass, while allowing subclasses to alter the type of objects to be created.
    /// </summary>
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }


        // It should be private
        private User(string name, string email, string countryCode)
        {
            Name = name;
            Email = email;
            CountryCode = countryCode;
        }

        public static class Factory
        {
            // The Creation behivor is only controled by a method
            public static User CreateColombianUser(string name, string email)
            {
                return new User(name, email, "CO");
            }
            // The Creation behivor is only controled by a method
            public static User CreateNorthAmericanUser(string name, string email)
            {
                return new User(name, email, "US");
            }
        }
    }



}


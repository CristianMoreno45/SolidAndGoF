namespace SolidAndGoF.SOLID.OpenClose
{
    public class ClassRefactored
    {
        // Define common User class (domain)
        public interface IUser
        {
            int Id { get; set; }
            string Email { get; }
            string Password { get; }
            IUserService Service { get; set; }
        }

        public class User
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

        }

        // Define Custom types of users
        public class Customer : IUser
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string? LastName { get; set; }
            public int? Age { get; set; }
            public string Email
            {
                get => $"{FirstName}.{LastName}_cutomer@example.com".ToLower();
            }
            public string Password { get; }

            public IUserService Service { get; set; } = new CustomerService();
        }

        public class Employee : IUser
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string? LastName { get; set; }
            public int? Age { get; set; }
            public string Job { get; set; }
            public string Email
            {
                get => $"{LastName}.{FirstName}_employee@example.com".ToLower();
            }
            public string Password { get; }
            public IUserService Service { get; set; } = new EmployeeService();
        }

        public class Provider : IUser
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email
            {
                get => $"{Name}_provider@example.com".ToLower();
            }
            public string Password { get; }

            public IUserService Service { get; set; } = new ProviderService();

        }

        // Define common intertface Service 
        public interface IUserService
        {
            User Create(IUser person);
        }

        // Define concrete Service by each user type

        public class CustomerService : IUserService
        {
            public User Create(IUser person)
            {
                User user = new User()
                {
                    Id = person.Id,
                    Email = person.Email,
                    Password = Guid.NewGuid().ToString()
                };
                return user;
            }
        }

        public class EmployeeService : IUserService
        {
            public User Create(IUser person)
            {
                User user = new User()
                {
                    Id = person.Id,
                    Email = person.Email,
                    Password = Guid.NewGuid().ToString()
                };
                return user;
            }
        }

        public class ProviderService : IUserService
        {
            public User Create(IUser person)
            {
                User user = new User()
                {
                    Id = person.Id,
                    Email = person.Email,
                    Password = Guid.NewGuid().ToString()
                };
                return user;
            }
        }

        public void Handle1()
        {
            List<IUser> people = new List<IUser>();
            List<User> users = new List<User>();
            try
            {
                people.Add(new Customer()
                {
                    Id = 1,
                    FirstName = "Jhon",
                    LastName = "Doe",
                    Age = 25

                });
                people.Add(new Employee()
                {
                    Id = 2,
                    FirstName = "Juan",
                    LastName = "Rodriguez",
                    Age = 31

                });
                people.Add(new Provider()
                {
                    Id = 3,
                    Name = "Bancolombia",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            foreach (IUser person in people)
            {
                users.Add( person.Service.Create(person));
            }
            int i = 1;
            foreach (User user in users)
            {
                Console.WriteLine($"User {i}: {Newtonsoft.Json.JsonConvert.SerializeObject(user)}");
                i++;
            }
        }

    }
}

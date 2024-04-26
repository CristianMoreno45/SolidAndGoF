namespace SolidAndGoF.SOLID.OpenClose
{
    public class ClassToRefactor
    {
        public class User
        {
            // Original Class
            public int Id;
            public string FirstName { get; set; }
            public string? LastName { get; set; }
            public int? Age;
            // CR1: Added Property
            public UserType Type;
            public string? Email;

        }

        public enum UserType
        {
            Customer,
            Employee,
            Provider
        }

        public class PersonService
        {
            public readonly List<User> People = new List<User>();

            public User Create(User person)
            {
                // Diferents behaviors peer type
                switch (person.Type)
                {
                    case UserType.Customer:
                        person.Email = $"{person.FirstName}.{person.LastName}_cutomer@example.com".ToLower();
                        return person;
                    case UserType.Employee:
                        person.Email = $"{person.LastName}.{person.FirstName}_employee@example.com".ToLower();
                        return person;
                    case UserType.Provider:
                        person.Email = $"{person.FirstName}_provider@example.com".ToLower();
                        return person;
                    default:
                         return new User();
                }
            }


        }
        public void Handle1()
        {
            List<User> Users = new List<User>();
            PersonService service = new PersonService();
            try
            {
                Users.Add(service.Create(new User()
                {
                    Id = 1,
                    FirstName = "Jhon",
                    LastName = "Doe",
                    Age = 25,
                    Type = UserType.Customer

                }));
                Users.Add(service.Create(new User()
                {
                    Id = 3,
                    FirstName = "Juan",
                    LastName = "Rodriguez",
                    Age = 31,
                    Type = UserType.Employee,

                }));
                Users.Add(service.Create(new User()
                {
                    Id = 3,
                    FirstName = "Bancolombia SA",
                    Type = UserType.Provider
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            int i = 1;
            foreach (User user in Users)
            {
                Console.WriteLine($"User {i}: {Newtonsoft.Json.JsonConvert.SerializeObject(user)}");
                i++;
            }
        }
    }
}

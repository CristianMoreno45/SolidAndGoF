using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Creational.Singleton
{
    /// <summary>
    /// It allows us to ensure that a class has a single instance, while providing a global access point to that instance.
    /// </summary>
    public interface IConfigurationSingletone
    {
        string GetConfiguration(string name);
    }
    public class Configuration : IConfigurationSingletone
    {
        private static Configuration _instance = new Configuration();
        private readonly Dictionary<string, string> _configuration = new Dictionary<string, string>();
        private Configuration()
        {
            Console.WriteLine("New instance");
            _configuration.Add("MainColor", "#FF0000");
            _configuration.Add("CompanyName", "MyCompany");
            _configuration.Add("CompanyAddress", "Ever Green Avenue, 123");
        }

        public static Configuration Intance() => _instance;
        public string GetConfiguration(string name)
        {
            if (_configuration.ContainsKey(name))
                return _configuration[name];
            else
                throw new NullReferenceException("This configuration Is not available");
        }
    }
}

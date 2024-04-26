using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.SOLID.InterfaceSegregation
{
    public class ClassRefactored
    {

        public interface IPrint
        {
            void Printer(string content);
        }

        public interface IScan
        {
            void Scan(string content);
        }

        public interface IFax
        {
            void Fax(string content);

        }

        public class HPLaserJetPrinter : IPrint,IFax,IScan
        {
            public void Fax(string content)
            {
                Console.WriteLine(content);
            }

            public void Printer(string content)
            {
                Console.WriteLine(content);
            }

            public void Scan(string content)
            {
                Console.WriteLine(content);
            }
        }

        public class SimplePrinter : IPrint,IScan
        {
            public void Printer(string content)
            {
                Console.WriteLine(content);
            }

            public void Scan(string content)
            {
                Console.WriteLine(content);
            }
        }
    }
}

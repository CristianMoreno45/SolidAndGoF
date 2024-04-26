using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.SOLID.InterfaceSegregation
{
    public class ClassToRefactor
    {
        public interface IPrinterTask 
        {
            void Fax(string content);
            void Printer(string content);
            void Scan(string content);
        }

        public class HPLaserJetPrinter : IPrinterTask
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

        public class SimplePrinter : IPrinterTask
        {
            public void Fax(string content)
            {
                throw new NotImplementedException();
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
    }
}

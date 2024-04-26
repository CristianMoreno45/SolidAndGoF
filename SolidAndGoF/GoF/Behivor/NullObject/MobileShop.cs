using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.NullObject
{
    public class MobileShop
    {
        public interface IMobile
        {
            void TurnOn();
        }

        public class SamsungGalaxy : IMobile
        {
            public void TurnOn()
            {
                Console.WriteLine("I'm Samsung");
            }
        }
        public class NullMobile : IMobile
        {
            /// <summary>
            ///  The best advise is: combine this patern with a singleton to have unique intance of this class
            /// </summary>
            public void TurnOn()
            {
                Console.WriteLine("I'm a mobile");
            }
        }

        public class Iphone : IMobile
        {
            public void TurnOn()
            {
                Console.WriteLine("I'm Iphone");
            }
        }


        public class MobileRepository
        {
            public IMobile GetMobileByName(string mobileName)
            {
                IMobile mobile = null;
                switch (mobileName)
                {
                    case "samsung":
                        mobile = new SamsungGalaxy();
                        break;

                    case "apple":
                        mobile = new Iphone();
                        break;
                    default:
                        mobile = new NullMobile();
                        break;
                }
                return mobile;
            }
        }
    }
}

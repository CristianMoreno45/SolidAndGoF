using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Structural.Decorator
{
    /// <summary>
    /// It allows adding functionalities to objects by placing these objects inside special wrapper objects that contain these functionalities.
    /// </summary>
    public class CoffeShop
    {
        public interface ICoffe
        {
            string Name { get; set; }
            double GetCost();
            string GetDescription();
        }

        public class Basic : ICoffe
        {
            public string Name { get; set; } = "Coffe";

            public double GetCost()
            {
                return 2;
            }
            public string GetDescription() {
                return Name;
            }
        }

        public abstract class AdditionDecorator : ICoffe
        {
            ICoffe _order;
            protected double _valueOrder = 0;
            public string Name { get; set; } = "";

            public AdditionDecorator(ICoffe order)
            {
                _order = order;

            }
            public double GetCost()
            {
                return _order.GetCost() + _valueOrder;
            }
            public string GetDescription()
            {
                return _order.GetDescription() + Name;
            }
        }
        public class AdditionOfMilk : AdditionDecorator
        {
            public AdditionOfMilk(ICoffe order) : base(order)
            {
                _valueOrder = 1;
                Name = ", with addition of milk";
            }
        }
        public class AdditionOfChocolate : AdditionDecorator
        {
            public AdditionOfChocolate(ICoffe order) : base(order)
            {
                _valueOrder = 0.5;
                Name = ", with addition of chocolate";
            }
        }
        public class AdditionOfCream : AdditionDecorator
        {
            public AdditionOfCream(ICoffe order) : base(order)
            {
                _valueOrder = 0.2;
                Name = ", with addition of cream";
            }
        }
    }
}

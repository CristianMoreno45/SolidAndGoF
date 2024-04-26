using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SolidAndGoF.GoF.Creational.AbstractFactory
{
    public class PizzaAbstractFactory {
        public abstract class Pizza
        {
            public string Name { get; set; }
            public string Dough { get; set; }
            public string Store { get; set; }
            public string Sauce { get; set; }
            public List<string> Toppings { get; set; } = new List<string>();

            public void Prepare() => Console.WriteLine("I'm preparing a pizza...");
            public void Cut() => Console.WriteLine("I'm cutting a pizza...");
            public void Box() => Console.WriteLine("I'm packing a pizza in the box ...");
        }

        public abstract class PizzaStoreFactory
        {
            public abstract Pizza Create(string name);
            public Pizza Order(string type)
            {
                Pizza pizza = Create(type);
                pizza.Prepare();
                pizza.Cut();
                pizza.Box();
                return pizza;
            }
        }

        public class ColombiaStoreFactory : PizzaStoreFactory
        {
            public override Pizza? Create(string name)
            {
                switch (name)
                {
                    case "Pepperoni":
                        return new ColombiaPepperoniPizza();
                    default:
                        return null;
                }
            }
        }

        public class UnitedStatesStoreFactory : PizzaStoreFactory
        {
            public override Pizza? Create(string name)
            {
                switch (name)
                {
                    case "Pepperoni":
                        return new ColombiaPepperoniPizza();
                    default:
                        return null;
                }
            }
        }

        public class ColombiaPepperoniPizza : Pizza
        {
            public ColombiaPepperoniPizza()
            {
                Name = "Pepperoni";
                Dough = "Flat";
                Sauce = "Tomato base";
                Store = "Colombia";
                Toppings.Add("Mozzarella Cheese");
            }
        }

        public class UnitedStatesPepperoniPizza : Pizza
        {
            public UnitedStatesPepperoniPizza()
            {
                Name = "Pepperoni";
                Dough = "Flat";
                Sauce = "Tomato base";
                Store = "United states";
                Toppings.Add("Mozzarella Cheese");
            }
        }
    }
    
}

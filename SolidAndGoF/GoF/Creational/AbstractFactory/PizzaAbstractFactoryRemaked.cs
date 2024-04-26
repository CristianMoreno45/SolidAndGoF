using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static SolidAndGoF.GoF.Creational.AbstractFactory.PizzaAbstractFactoryRemaked;
using static SolidAndGoF.GoF.Creational.FactoryMethod.User;
using static System.Formats.Asn1.AsnWriter;

namespace SolidAndGoF.GoF.Creational.AbstractFactory
{
    /// <summary>
    /// It allows producing families of related objects without specifying their concrete classes.
    /// </summary>
    public class PizzaAbstractFactoryRemaked
    {
        public abstract class Pizza
        {
            public string Name { get; set; }
            public string Store { get; set; }
            public IDough Dough { get; set; }
            public ISauce Sauce { get; set; }
            public ICheese Cheese { get; set; }
            public List<ITopping> Toppings { get; set; } = new List<ITopping>();

            public abstract void Prepare();

            public void Cut() => Console.WriteLine("I'm cutting a pizza...");
            public void Box() => Console.WriteLine("I'm packing a pizza in the box ...");

        }

        public enum PizzaType
        {
            Pepperoni,
            Hawaiian,
            Chiken,
            Cheese
        }

        public interface IPizzaIngredientFactory
        {
            IDough CreateDough();
            ISauce CreateSauce();
            ICheese CreateCheese();
            List<ITopping> CreateToppings();

        }

        public abstract class PizzaStore
        {
            public abstract Pizza Create(PizzaType type);
            public Pizza Order(PizzaType type)
            {
                Pizza pizza = Create(type);
                pizza.Prepare();
                pizza.Cut();
                pizza.Box();
                return pizza;

            }

        }



        public class ColombiaStore : PizzaStore
        {

            public override Pizza Create(PizzaType type)
            {
                string pizzaType = Enum.GetName(typeof(PizzaType), type);
                if (pizzaType != null)
                {
                    Type? factoryType = Type.GetType($"SolidAndGoF.GoF.Creational.AbstractFactory.PizzaAbstractFactoryRemaked+{pizzaType}PizzaIngredientFactory");
                    if (factoryType != null)
                    {
                        IPizzaIngredientFactory ingredientsFactory = Activator.CreateInstance(factoryType) as IPizzaIngredientFactory;

                        Type? pizzaFactory = Type.GetType($"SolidAndGoF.GoF.Creational.AbstractFactory.PizzaAbstractFactoryRemaked+{pizzaType}Pizza");
                        if (pizzaFactory != null)
                        {
                            return Activator.CreateInstance(pizzaFactory, ingredientsFactory, "Colombia") as Pizza;
                        }
                    }
                }
                throw new Exception("We doesn't have this kind of pizza.");
            }
        }

        #region Factory of ingredients
        public class ColombiaPepperoniPizzaIngredientFactory : IPizzaIngredientFactory
        {
            public ColombiaPepperoniPizzaIngredientFactory()
            {
            }

            public ICheese CreateCheese()
            {
                return new Mozzarella();
            }

            public IDough CreateDough()
            {

                return new FlatDough();
            }

            public ISauce CreateSauce()
            {


                return new CarbonaraSauce();
            }

            public List<ITopping> CreateToppings()
            {
                return new List<ITopping> { new Tomato(), new Onion() };
            }
        }

        public class ColombiaHawaiianPizzaIngredientFactory : IPizzaIngredientFactory
        {
            public ColombiaHawaiianPizzaIngredientFactory()
            {
            }

            public ICheese CreateCheese()
            {
                return new Mozzarella();
            }

            public IDough CreateDough()
            {

                return new GreekDough();
            }

            public ISauce CreateSauce()
            {
                return new TomatoSauce();
            }

            public List<ITopping> CreateToppings()
            {
                return new List<ITopping> { new Pineapple(), new Onion() };
            }
        }

        #endregion 

        #region Pizza concrete classes
        public class PepperoniPizza : Pizza
        {
            IPizzaIngredientFactory _factory;


            public PepperoniPizza(IPizzaIngredientFactory factory, string store)
            {
                _factory = factory;
                Name = "Peperoni";
                Store = store;
            }

            public override void Prepare()
            {
                Console.WriteLine($"I'm preparing a pizza {Name} in {Store}");
                Dough = _factory.CreateDough();
                Sauce = _factory.CreateSauce();
                Toppings = _factory.CreateToppings();
                Cheese = _factory.CreateCheese();
            }
        }

        public class HawaiianPizza : Pizza
        {
            IPizzaIngredientFactory _factory;


            public HawaiianPizza(IPizzaIngredientFactory factory, string store)
            {
                _factory = factory;
                Name = "Hawaiian";
                Store = store;
            }

            public override void Prepare()
            {
                Console.WriteLine($"I'm preparing a pizza {Name} in {Store}");
                Dough = _factory.CreateDough();
                Sauce = _factory.CreateSauce();
                Toppings = _factory.CreateToppings();
                Cheese = _factory.CreateCheese();
            }
        }

        #endregion

        #region Interfaces of models
        public interface IDough
        {
        }

        public interface ISauce
        {
        }

        public interface ICheese
        {
        }

        public interface ITopping
        {
        }
        #endregion

        #region Model
        public class FlatDough : IDough
        {
            public FlatDough()
            {
                Console.WriteLine("I'm kneading flat Dough.");
            }
        }

        public class GreekDough : IDough
        {
            public GreekDough()
            {
                Console.WriteLine("I'm kneading Greek Dough.");
            }
        }

        public class CarbonaraSauce : ISauce
        {
            public CarbonaraSauce()
            {
                Console.WriteLine("I'm appling Carbonara sauce.");
            }
        }

        public class TomatoSauce : ISauce
        {
            public TomatoSauce()
            {
                Console.WriteLine("I'm appling Tomato sauce.");
            }
        }
        public class Mozzarella : ICheese
        {
            public Mozzarella()
            {
                Console.WriteLine("I'm adding Mozzarella cheese.");
            }
        }

        public class Onion : ITopping
        {
            public Onion()
            {
                Console.WriteLine("I'm appling slices of Tomato.");
            }
        }

        public class Tomato : ITopping
        {
            public Tomato()
            {
                Console.WriteLine("I'm appling slices of Onion.");
            }
        }
        public class Pineapple : ITopping
        {
            public Pineapple()
            {
                Console.WriteLine("I'm appling slices of Pineapple.");
            }
        }
        #endregion
    }

}

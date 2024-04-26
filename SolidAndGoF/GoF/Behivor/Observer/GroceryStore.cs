using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.Observer
{
    public class GroceryStore
    {
        public interface IRestaurant
        {
            void Update(Fruits fruits);
        }


        public abstract class Fruits
        {
            private double _pricePerKg;
            private List<IRestaurant> _restaurants = new List<IRestaurant>();

            protected Fruits(double pricePerKg)
            {
                _pricePerKg = pricePerKg;
            }

            public void Attach(IRestaurant restaurant)
            {
                _restaurants.Add(restaurant);
            }

            public void Detach(IRestaurant restaurant)
            {
                _restaurants.Remove(restaurant);
            }

            public void Notify()
            {
                foreach (IRestaurant restaurant in _restaurants)
                {
                    restaurant.Update(this);
                    
                }



            }

            public double PricePerKg
            {
                get { return _pricePerKg; }
                set
                {
                    if (_pricePerKg != value)
                    {
                        _pricePerKg = value;
                        Notify();
                    }
                }
            }

        }

        public class Lemon : Fruits
        {
            public Lemon(double pricePerKg) : base(pricePerKg)
            {
            }
        }

        public class Restaurant : IRestaurant
        {
            private string _name;
            private double _purchaseThreshold;

            public Restaurant(string name, double purchaseThreshold)
            {
                _name = name;
                _purchaseThreshold = purchaseThreshold;
            }

            public void Update(Fruits fruits)
            {
                Console.WriteLine($"I ({_name}) was notified that the price of {fruits.GetType().Name} changed to {fruits.PricePerKg}");

                if (fruits.PricePerKg < _purchaseThreshold)
                {
                    Console.WriteLine($"I ({_name}) want to buy {fruits.GetType().Name}!");
                }
                
            }
        }
    }
}

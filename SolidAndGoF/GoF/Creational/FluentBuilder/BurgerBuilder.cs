using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Creational.FluentBuilder
{
    public class BurgerBuilder
    {
        protected Burger _burger { get; set; } = new Burger();
        public Burger Burger { get => _burger; }


        public BurgerBuilder WithBread()
        {
            _burger.Bread = "Brioche with oregan";
            return this;
        }
        public BurgerBuilder WithProtein()
        {
            _burger.Protein = "Ribeye";
            return this;
        }
        public BurgerBuilder WithCheese()
        {
            _burger.Cheese = "Cheddar X2";
            return this;
        }
        public BurgerBuilder WithVeggies()
        {
            _burger.Veggies = "";
            return this;
        }
        public BurgerBuilder WithCondiments()
        {
            _burger.Condiments = "Mayonnaise";
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Creational.Builder
{
    public abstract class BurgerBuilder
    {
        protected Burger _burger { get; set; }
        public Burger Burger { get => _burger; }
        public abstract void AddBread();
        public abstract void AddProtein();
        public abstract void AddCheese();
        public abstract void AddVeggies();
        public abstract void AddCondiments();
    }
}

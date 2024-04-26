namespace SolidAndGoF.GoF.Creational.Builder
{
    public class CheeseBurger: BurgerBuilder
    {
        public CheeseBurger()
        {
            _burger = new Burger();
        }
        public override void AddBread()
        {
            _burger.Bread = "Brioche with oregan";
        }
        public override void AddProtein()
        {
            _burger.Protein = "Ribeye";
        }
        public override void AddCheese()
        {
            _burger.Cheese = "Cheddar X2";
        }
        public override void AddVeggies()
        {
            _burger.Veggies = "";
        }
        public override void AddCondiments()
        {
            _burger.Condiments = "Mayonnaise";
        }
    }
}

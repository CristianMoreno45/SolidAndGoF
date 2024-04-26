namespace SolidAndGoF.GoF.Creational.Builder
{
    /// <summary>
    /// Allows you to build complex objects step by step. This pattern allows us to produce different types and representations of an object using the same construction code.
    /// </summary>
    public class BurgerAssembly
    {
        private BurgerBuilder _builder;
        public Burger GetBurguer { get => _builder.Burger; }
        public BurgerAssembly(BurgerBuilder builder)
        {
            _builder = builder;
        }

        public void AssembleBurguer()
        {
            _builder.AddBread();
            _builder.AddProtein();
            _builder.AddCheese();
            _builder.AddVeggies();
            _builder.AddCondiments();
        }
    }

}

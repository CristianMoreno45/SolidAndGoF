using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.Command
{
    public class eShop
    {
        public class Product
        {
            public Product(string name, int price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; set; }
            public int Price { get; set; }

            public void IncreasePrice(int amount)
            {
                Price += amount;
                Console.WriteLine($"The price of {Name} is incremented in {amount}");
            }

            public bool DecreasePrice(int amount)
            {
                if (amount < Price)
                {
                    Price -= amount;
                    Console.WriteLine($"The price of {Name} is decremented in {amount}");
                    return true;
                }
                return false;
            }

            public override string ToString() => $"The actual price of {Name} is {Price}";
        }

        public interface ICommand
        {
            void Execute();
            void Undo();
        }
        public enum PriceAction
        {
            Increase,
            Decrease
        }

        public class ProductCommand : ICommand
        {
            private Product _product;
            private PriceAction _priceAction;
            private int _amount;

            public bool IsCommandExecuted { get; private set; }
            public ProductCommand(Product product, PriceAction priceAction, int amount)
            {
                _product = product;
                _priceAction = priceAction;
                _amount = amount;
            }

            public void Execute()
            {
                if (_priceAction == PriceAction.Increase)
                {
                    _product.IncreasePrice(_amount);
                    IsCommandExecuted = true;
                }
                else
                {
                    IsCommandExecuted = _product.DecreasePrice(_amount);
                }
            }

            public void Undo()
            {
                if (!IsCommandExecuted)
                    return;

                if (_priceAction == PriceAction.Increase)
                {
                    _product.DecreasePrice(_amount);
                }
                else
                {
                    _product.IncreasePrice(_amount);
                }
            }
        }

        public class ModifyPriceCommand
        {
            private List<ICommand> _commands;
            private ICommand _command;

            public ModifyPriceCommand()
            {
                _commands = new List<ICommand>();
            }

            public void SetCommand(ICommand command) => _command = command;

            public void Invoke()
            {
                _commands.Add(_command);
                _command.Execute();
            }

            public void Undo()
            {
                foreach (var command in Enumerable.Reverse(_commands))
                {
                    command.Undo();
                }
            }

        }
    }
}

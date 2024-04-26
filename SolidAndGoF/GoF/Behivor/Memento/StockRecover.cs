using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.Memento
{
    public class StockRecover
    {
        public class Memento
        {
            public int Price { get; set; }
            public Memento(int price)
            {
                Price = price;
            }
        }

        public class Product
        {
            public int Price { get; set; }
            private List<Memento> _history;
            private int _index = 0;
            public Product(int price)
            {
                Price = price;
                _history = new List<Memento>() { new Memento(Price) };

            }

            public void ChangePrice(int price)
            {
                Price += price;
                _index++;
                _history.Add(new Memento(Price));
            }

            public void Undo()
            {
                var memento = _history[--_index];
                Price = memento.Price;
            }
            public void Redo()
            {
                var memento = _history[++_index];
                Price = memento.Price;
            }

        }
    }
}
